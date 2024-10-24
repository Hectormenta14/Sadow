using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimePasAction (A)", menuName = "ScriptableObject/actions/TimePasactions")]
public class TimePasAction : actions // accion para determinar si ha pasado un tiempo o no 
{
    public float maxTime;
    private float currentTime = 0;
    public override bool Check(GameObject owner) // checkea que sea true o false, queremos que cada vez que se invoque el check el currenttime crezca
    {
        currentTime = Time.deltaTime; // deltaTime es el tiempoq que pasa entre frame y si le vamos sumando es como un cronometro 
        if (currentTime > maxTime)
        {
            currentTime = 0; // hay que reiniciar el contador
            return true;
        }
        return false;
    }


    public override void DrawGizmo(GameObject owner) // lo dejamos vacio por que en el tiempo no hay que dibujar nada
    {

    }
}
  
