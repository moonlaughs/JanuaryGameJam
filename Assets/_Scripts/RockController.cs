using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RockController : MonoBehaviour
{
    public bool isMoving;
    public Transform player;
    NavMeshAgent agent;
    private Rigidbody rigidbody;

    public int rockDamaged;

    void Start()
    {
        isMoving = false;
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distance = Vector3.Distance(agent.transform.position, player.position);

        if (isMoving)
        {
            agent.isStopped = false;
            agent.transform.LookAt(player);
            agent.SetDestination(player.position);
        } else {
            agent.isStopped = true;
            agent.SetDestination(agent.transform.position);
        }
    }

    public void SetIsMoving(bool moving)
    {
        isMoving = moving;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Health>().damageDeal(rockDamaged);
        }
    }
}
