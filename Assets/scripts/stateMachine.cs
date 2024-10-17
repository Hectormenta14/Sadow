using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateMachine : MonoBehaviour
{
    public stado initialState;
    private stado currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
    }

    // Update is called once per frame
    void Update()
    {
         stado nextState = currentState.Run(gameObject); // el run nos devuelve un estado que o es nuelo o es el siguemte en caso de que alguna accion se cumple
        // nos lo almacenamos en una variable
        if (nextState)
        {
            currentState = nextState; // si nextstate no es nulo = el run ha decidido que una de las acciones se ha cumplido ps cambiamos de estado y si no se ejecuta run todo el rato
        }


    }
    public void OnDrawGizmos()
    {
        if (currentState) // si no le damos a play currentstate no tiene nada y llama al metodo con algo que no tiene nada asi que si initial o current state tiene algo lo dibujas
        currentState.DrawAllActionsGizmos(gameObject);
        else if(initialState)
            initialState.DrawAllActionsGizmos(gameObject);
    }
}
