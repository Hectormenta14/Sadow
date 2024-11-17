using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct ActionParameters //relacionar un booleano con una accion
{
    public actions action; // acciones q van a ser ejecutadas
    public bool actionValue;// indica si la accion check es falso o verdadero
}
[System.Serializable]
public struct stadoParameters
{
    public ActionParameters[] actionParameters; //array
    public stado nextstado; // si la accion check = actionValue el next stado pushed
    public bool and; // se cumplen todas las acciones o solo se tiene que cumplir una 

}
public abstract class stado : ScriptableObject // por que el run no va ha hacer nada
{

    public stadoParameters[] stadoParameters;
    protected stado CheckActions(GameObject owner)
    {
        for (int i = 0; i < stadoParameters.Length; i++) //recorre el array entero comprobando si la accion se cumple para cambiar el estado
        {
            bool TodasLasAcionesSeHanCumplido = true; //asumimos que todas las acciones se han cumplido 
            for (int j = 0; j < stadoParameters[i].actionParameters.Length; j++) // en el primer for recorremos el array de los parametros y en los parametros hay otro array
                                                                        // que hay que recorrer para ver si las acciones se cumplen o no 
            {
                ActionParameters actionParameters = stadoParameters[i].actionParameters[j];
                if (actionParameters.action.Check(owner) == actionParameters.actionValue) // si el check de la accion cumple con su valor asignado
                {//hay que comprobarlo con el and
                    if (!stadoParameters[i].and) // si solo se le cumple una 
                     {
                        return stadoParameters[i].nextstado; // devolvemos directamente el siguente estado
                    }

                }
                else if (stadoParameters[i].and)
                {
                    TodasLasAcionesSeHanCumplido = false; // lo ponemos por si acaso no se ha cumplido alguna de las acciones
                    // si llegamos a este if estamos seguros de que esta accion no se ha cumplido
                    // y el diseñador ha marcado que se tienen que cumplir todas
                    break; //salimos del bucle, por que una accion no se ha cumplido y estamos en and
                    // despues del break todo codigo es inacessible
                }
            }
            //como hay un array dentro de otro haces 2 for para recorrerlos
            // si llegamos hasta aqui, significa que el diseñador ha marcadi que todas las acciones 
            // tienen que cumplirse. Tenemos que comprobar si de verdad se han cumplido todas
            if (stadoParameters[i].and)
            {
                return null; //return del siguente estado
            }

        }
        return null; // devolvemos true si algunas de sus acciones se cumple o false si es al contrario 
    }
    public abstract stado Run(GameObject owner); //compreba si las acciones se cumplen y ademas ejecuta el comportamiento asociado al estado
    //state machine cambio de estado de la ia
    public void DrawAllActionsGizmos(GameObject owner)
    {
        foreach (stadoParameters parameters in stadoParameters)
        {
            foreach (ActionParameters aP in parameters.actionParameters)
            {
                aP.action.DrawGizmo(owner);
            }
        }
    }
}



