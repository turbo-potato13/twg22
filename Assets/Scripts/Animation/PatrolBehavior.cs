using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : StateMachineBehaviour
{
    private float timer;
    private List<Transform> points = new List<Transform>();
    private NavMeshAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform tr in pointsObject)
        {
            points.Add(tr);
        }

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if (agent.remainingDistance <= agent.stoppingDistance)
        // {
            agent.SetDestination(points[Random.Range(0, points.Count)].position);
        // }

        timer += Time.deltaTime;
        if (timer > 7)
        {
            animator.SetBool("IsPatroling", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}