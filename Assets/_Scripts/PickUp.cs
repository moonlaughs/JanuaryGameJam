using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    bool KeyCard = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KeyCard")
        {
            KeyCard = true;
            Destroy(gameObject);
        }
    }
}
