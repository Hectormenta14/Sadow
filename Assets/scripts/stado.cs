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
    //private bool CheckActions()
    // {
    //     // devolvemos true si algunas de sus acciones se cumple o false si es al contrario 
    // }
    public abstract stado Run(GameObject owner);
    //state machine cambio de estado de la ia
    //state machine cambio de estado de la ia
}
