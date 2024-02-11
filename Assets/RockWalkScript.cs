using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RockWalkScript : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    Transform rock; 
    float chaceRange = 2;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rock = GameObject.FindGameObjectWithTag("Rock").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rock.transform.Translate(Vector3.forward * Time.deltaTime ); //* Input.GetAxis("Vertical")
        // rock.SetDestination(player.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if(distance < chaceRange){
            animator.SetBool("isJumping", true);
            // Application.Quit(); // works in game build
            // UnityEditor.EditorApplication.isPlaying = false; // works in Unity Engine only
        }
        // else
        // {
        //     animator.SetBool("isWalking", true);
        // }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
                rock.transform.Translate(Vector3.forward * Time.deltaTime ); //* Input.GetAxis("Vertical")

    //    agent.SetDestination(agent.transform.position);
    }
}
