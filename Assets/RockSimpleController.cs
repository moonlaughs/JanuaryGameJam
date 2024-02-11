using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RockSimpleController : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    private Rigidbody rigidbody;
    private bool grounded = true;
    private bool jumped = false;
    
    public int rockDamaged;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distance = Vector3.Distance(agent.transform.position, player.position);

        // if(distance < 2f && grounded && jumped == true)
        // {
        //     agent.SetDestination(transform.position);
        //     jumped = false;
        // }
        // else 
        // if(distance < 5f && grounded && jumped == false)
        // {  
        //     grounded = false;
        //     if (agent.enabled)
        //     {
        //         // set the agents target to where you are before the jump
        //         // this stops her before she jumps. Alternatively, you could
        //         // cache this value, and set it again once the jump is complete
        //         // to continue the original move
        //         agent.SetDestination(agent.transform.position);
        //         // disable the agent
        //         agent.updatePosition = false;
        //         agent.updateRotation = false;
        //         agent.isStopped = true;
        //     }
        //     // make the jump
        //     jumped = true;
        //     rigidbody.isKinematic = false;
        //     rigidbody.useGravity = true;
        //     rigidbody.AddRelativeForce(new Vector3(0.5f, 5f, 0), ForceMode.Impulse);    
        // } else
         if (distance < 8f)
        {
            agent.isStopped = false;
            agent.transform.LookAt(player);
            agent.SetDestination(player.position);
        } else {
            agent.isStopped = true;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null && collision.collider.tag == "Ground")
        {
            if (!grounded)
            {
                if (agent.enabled)
                {
                    agent.updatePosition = true;
                    agent.updateRotation = true;
                    agent.isStopped = false;
                }
                rigidbody.isKinematic = true;
                rigidbody.useGravity = false;
                grounded = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("dealing demage");
            // other.GetComponent<Health>().damageDeal(rockDamaged);
        }
    }
}
