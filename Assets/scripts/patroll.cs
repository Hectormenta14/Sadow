using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class patroll : StateMachineBehaviour
{
    float timer;
    List<Transform> Waypoints = new List<Transform>(); //crea la lista de los puntos de la patrulla
    NavMeshAgent agent;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("way");
        foreach (Transform t in go.transform)
        {
            Waypoints.Add(t);
        }
        agent.SetDestination(Waypoints[Random.Range(0, Waypoints.Count)].position);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(Waypoints[Random.Range(0, Waypoints.Count)].position);
        }
        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatroll",false);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      agent.SetDestination(agent.transform.position);   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
