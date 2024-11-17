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
    public string BlendParameter;
    public override stado Run(GameObject owner)
    {
        stado nextState = CheckActions(owner); //accedemos al metodo check actios
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();
        navMeshAgent.SetDestination(guardPoint); // su destino es el el punto que tine q montar guardia
        animator.SetFloat(BlendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed); // lo dividimos por que quede entre 0 o 1
        

        return nextState;

       
    }

    
}
