using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockIdleScript : StateMachineBehaviour
{
    float timer;
    Transform player;
    float chaceRange = 2f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        // if(timer > 1)
        //    {
        //     //  animator.SetBool("isWalking", true);
        //     animator.SetBool("isJumping", true);
        //      }


        float distance = Vector3.Distance(animator.transform.position, player.position);
        Debug.Log(distance);
        if(distance < 10f)
        {
            animator.transform.Translate(player.position.x, 0f, 0f);
        }
        if(distance < chaceRange)
            animator.SetBool("isJumping", true);

            // gameobject.transofrm.translate
    }
}
