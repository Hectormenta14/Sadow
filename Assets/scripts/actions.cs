using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class actions : ScriptableObject
{
    public bool value; // si la accion se tiene que cumplir o no ( si ve al jugador o si no lo ve)
  public abstract bool Check(GameObject owner); // recivimos el ouwner por que lo vamos a ejecutar 
    public abstract void DrawGizmo(GameObject owner); 
}
