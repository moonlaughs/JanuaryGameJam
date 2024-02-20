using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip lightClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(lightClip);
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject go in gos)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance < 30f)
                {
                    go.GetComponent<EnemyController>().SetIsMoving(true);
                }
            }
        }
    }
}
