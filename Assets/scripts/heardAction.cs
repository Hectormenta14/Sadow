using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "heardAction (s)", menuName = "ScriptableObjects/actions/heardAction")]
public class heardAction : actions
{
    public float radious = 20f;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position,radious, Vector3.up); //aparece el rayo de la esfera (hace una esfera sin mas alrededor del enemigo)
        GameObject target = owner.GetComponent<targetReferences>().target;
        foreach (RaycastHit hit in hits)  // recorremos todos los objetos dentro de la esfera y si alguno de ellos conincide con el objetivo debuelvo true por que le he escuchado
        {
            if(hit.collider.gameObject == target)
            {
                //le hemos  escuchado u olido
                return true; // le escucho 
            } 
          
        }
        return false; // no le escucho
    }

    public override void DrawGizmo(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(owner.transform.position,radious); //area de sonido
    }
    // Haria un metodo abstracto (en el estado) que recorriese todos los parametros he incorporase a ns gizmo y en el statemachine haces ondrowgizmos y llamas al metodo del stado para que se dibujan todos los gizmos
}
