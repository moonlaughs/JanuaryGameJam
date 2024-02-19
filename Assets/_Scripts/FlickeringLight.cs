using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] float timer;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip lightClip;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        FlickerLight();
    }

    void FlickerLight()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
        if (timer <= 0)
        {
            light.enabled = !light.enabled;
            timer = Random.Range(minTime, maxTime);
            audioSource.PlayOneShot(lightClip);
        }
    }
}
