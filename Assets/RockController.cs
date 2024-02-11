using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RockController : MonoBehaviour
{
    public Animator rockAnimator;
    public Transform player;
    NavMeshAgent agent;
    // Rigidbody rb;
 
    void Awake()
    {
        agent = rockAnimator.GetComponent<NavMeshAgent>();
        // rb = rockAnimator.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distance = Vector3.Distance(rockAnimator.transform.position, player.position);
        
         if(distance < 2f)
        {
            Debug.Log(rockAnimator.transform.position);
            // agent.SetDestination();
            agent.SetDestination(rockAnimator.transform.position);
            // rockAnimator.enabled = true;
            // rockAnimator.Play("Rocky Jump");

            rockAnimator.SetBool("isJumping", true);
            // rockAnimator.SetBool("isWalking", false);
        } 
        // else if(distance < 3f) {
            
        //     // agent.SetDestination(rockAnimator.transform.position);
        //     // rockAnimator.enabled = true;
        // } 
        else if( distance < 5f)
        {
            Debug.Log(player.position);
        rockAnimator.transform.LookAt(player);
            rockAnimator.enabled = false;
            rockAnimator.SetBool("isJumping", false);
            rockAnimator.SetBool("isWalking", true);
            agent.SetDestination(player.position);
            // rb.MovePosition(player.position);
        }
         
    }
}
