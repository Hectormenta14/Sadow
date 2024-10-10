using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "ChaseState (s)", menuName = "ScriptableObjects/stados/ChaseState"  )] // para crear una opcion en el menu para crear estados y acciones
                                                                                                   // sin necesidad de codificar nada 
                                                                                                   // sciptable object es un cacho de codigo que sacamos a los diseñadores para que puedan modificarlos
                                                                                                   // sin tocar el codigo
public class ChaseState : stado
{
    public override stado Run(GameObject owner)
    {
       stado nextState = CheckActions(owner); //accedemos al metodo check actios
       
        // que persiga al jugador
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>(); //owner es el dueño de la maquina de estados y accedemos desde el al NavMeshAgent
        GameObject target = owner.GetComponent<targetReferences>().target; //olle owner dame tu componente target
        navMeshAgent.SetDestination(target.transform.position); // le dice al componente que vaya a la posicion de su objetivo por muchos obstaculos que haya
        return nextState;
    }
    

}
