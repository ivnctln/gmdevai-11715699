using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (opponent != null)
        {
            agent.SetDestination(opponent.transform.position);
        }
    }
}