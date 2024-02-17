using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlider : MonoBehaviour
{
    public GameObject Door;
    bool playerIsHere = false;
    [SerializeField] float openSpeed = 5f;
    [SerializeField] float maxOpen = 5f;
    [SerializeField] float maxClose = 0f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip lightClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsHere == true)
        {
            if (Door.transform.position.y < maxOpen)
            {
                Door.transform.Translate(0f, openSpeed * Time.deltaTime, 0f);
            }
        }
        else 
        { 
            if (Door.transform.position.y > -maxClose)
            {
                Door.transform.Translate(0f, -openSpeed * Time.deltaTime, 0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsHere = true;
            audioSource.PlayOneShot(lightClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsHere = false;
            audioSource.PlayOneShot(lightClip);
        }
    }

}
