using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
             GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("rock");
            foreach (GameObject go in gos)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance < 10f)
                {
                    go.GetComponent<RockController>().SetIsMoving(true);
                }
            }
        }
    }
}
