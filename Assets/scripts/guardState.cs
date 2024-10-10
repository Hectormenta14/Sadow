using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "guardState (s)", menuName = "ScriptableObjects/stados/guardState")]
public class guardState : stado
{
    public Vector3 guardPoint; 
    public override stado Run(GameObject owner)
    {
        stado nextState = CheckActions(owner); //accedemos al metodo check actios
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(guardPoint); // su destino es el el pinto que tine q montar guardia
        return nextState;

       
    }

    
}
