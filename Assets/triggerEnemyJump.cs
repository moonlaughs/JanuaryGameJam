using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class triggerEnemyJump : MonoBehaviour
{
    private Transform player;
    List<Transform> rocks = new List<Transform>();

    public float speed = 1.0f;
    bool isMoving = false;
    
    private bool grounded = true;
    private bool jumped = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform rocksObject = GameObject.FindGameObjectWithTag("Rocks").transform;
       foreach (Transform t in rocksObject)
       {    
            rocks.Add(t);
       }
    }

    void Update()
    {
        if(isMoving)
        {
            foreach (var rock in rocks)
            {
                rock.LookAt(player);
                
        //             NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //             Rigidbody rigidbody = GetComponent<Rigidbody>();
        //         float distance = Vector3.Distance(rock.position, player.position);
        //         if(distance < 2f && grounded && jumped == true)
        //         {
        //             agent.SetDestination(transform.position);
        //             jumped = false;
        //         }
        //         else
        //         if(distance < 2f)
        //         {
        //             grounded = false;

        //             if (agent.enabled)
        //     {
        //         // set the agents target to where you are before the jump
        //         // this stops her before she jumps. Alternatively, you could
        //         // cache this value, and set it again once the jump is complete
        //         // to continue the original move
        //         agent.SetDestination(transform.position);
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
        //         }
        //         // rock.position = Vector3.MoveTowards(rock.position, player.position, speed * Time.deltaTime);
        // // float dist = Vector3.Distance(rock.position, player.position);
        // //         if(dist < 4f)
        // //         {
        // //             // this will make all rocks stop moving - should be fixed
        // //             isMoving = false;
        // //         }
            }
        }

    }

    void OnTriggerEnter(Collider col)
    {
        isMoving = true;
    }
}
