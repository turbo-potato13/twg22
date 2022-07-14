using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.rotation = Quaternion.LookRotation(player.transform.position - animator.transform.position);
        animator.transform.LookAt(player);
        //animator.transform.rotation = Quaternion.Euler(0, animator.transform.rotation.y, 0);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance > 2)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}