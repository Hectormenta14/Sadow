using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct stadoParameters
{
    public bool actionValue; // indica si la accion check es falso o verdadero
    public actions action; // acciones q van a ser ejecutadas
    public stado nextstado; // si la accion check = actionValue el next stado pushed

}
public abstract class stado : ScriptableObject // por que el run no va ha hacer nada
{

    public stadoParameters[] stadoParameters;
    protected stado CheckActions(GameObject owner)
    {
        for (int i = 0; i < stadoParameters.Length; i++) //recorre el array entero comprobando si la accion se cumple para cambiar el estado
        {
            if (stadoParameters[i].actionValue == stadoParameters[i].action.Check(owner)) //chekea si se hace la accion 
            {
                return (stadoParameters[i].nextstado);
            }

        }
        return null; // devolvemos true si algunas de sus acciones se cumple o false si es al contrario 
    }
    public abstract stado Run(GameObject owner); //compreba si las acciones se cumplen y ademas ejecuta el comportamiento asociado al estado
    //state machine cambio de estado de la ia
    
}



