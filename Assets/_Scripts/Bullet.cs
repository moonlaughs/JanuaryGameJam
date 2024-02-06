using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int bulletDamaged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.GetComponent<Health>().damageDeal(bulletDamaged);
            Destroy(gameObject);
        }
    }
}
