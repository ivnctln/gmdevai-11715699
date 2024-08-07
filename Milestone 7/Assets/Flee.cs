using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = NPC.transform.position - opponent.transform.position;

        direction.Normalize();

        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    rotSpeed * Time.deltaTime);

        NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
