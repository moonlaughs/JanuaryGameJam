using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunBarrel;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifeTime;
    [SerializeField] float ammoCount;
    [SerializeField] float maxAmmo;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootClip;
    [SerializeField] AudioClip emptyClip;


    private void Start()
    {
        ammoCount = maxAmmo;
    }
    void Update()
    {
        if (ammoCount > 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(shootClip);
            GameObject instance = Instantiate(bullet, gunBarrel.position, Quaternion.identity);
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = instance.transform.forward + Camera.main.transform.forward * bulletSpeed;
            }
            Destroy(instance, bulletLifeTime);
            ammoCount--;
        }
    }
}
