using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM
{
    GameObject[] waypoints;
    int currentWaypoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        string waypointTag = NPC.GetComponent<RobotAI>().waypointTag;
        waypoints = GameObject.FindGameObjectsWithTag(waypointTag);
        currentWaypoint = 0;

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].transform.position);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;

        if (agent.remainingDistance < accuracy)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].transform.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }
}