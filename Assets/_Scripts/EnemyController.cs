using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public bool isMoving;
    Transform player;
    NavMeshAgent agent;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip lightClip;

    int rockDamage = 10;
    float minDistanceToPlayer = 6f;

    void Start()
    {
        isMoving = false;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(agent.transform.position, player.position);
        if (distance <= minDistanceToPlayer)
        {
            SetIsMoving(true);
            audioSource.clip = lightClip;
            audioSource.Play(0);
        }

        if (isMoving)
        {
            agent.isStopped = false;
            agent.transform.LookAt(player);
            agent.SetDestination(player.position);
            audioSource.clip = lightClip;
            audioSource.Play(0);
        }
        else
        {
            agent.isStopped = true;
            agent.SetDestination(agent.transform.position);
            audioSource.Pause();
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
            other.GetComponent<Health>().damageDeal(rockDamage);
            
        }
    }
}
