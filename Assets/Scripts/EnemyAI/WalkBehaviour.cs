using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehaviour : StateMachineBehaviour
{
    float timer ;
    List<Transform> wayPoint = new List<Transform>();
    NavMeshAgent agent;

    Transform Player;
    float RunRange = 15;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform wayPointObject = GameObject.FindGameObjectWithTag("WayPoint").transform;
        foreach(Transform t in wayPointObject)
        {
            wayPoint.Add(t);
        }

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoint[0].position);

        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(wayPoint[Random.Range(0, wayPoint.Count)].position);
        }

        timer += Time.deltaTime;
        if(timer > 10)
        {
            animator.SetBool("isWalking", false);
        }

        float distance = Vector3.Distance(animator.transform.position, Player.position);
        if(distance < RunRange)
        {
            animator.SetBool("isRunning", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
