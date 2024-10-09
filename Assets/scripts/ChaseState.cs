using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState (s)", menuName = "ScriptableObjects/stados/ChaseState"  )] // para crear una opcion en el menu para crear estados y acciones
                                                                                                   // sin necesidad de codificar nada 
                                                                                                   // sciptable object es un cacho de codigo que sacamos a los diseñadores para que puedan modificarlos
                                                                                                   // sin tocar el codigo
public class ChaseState : stado
{
    public override stado Run(GameObject owner)
    {
        throw new System.NotImplementedException();

    }

}
