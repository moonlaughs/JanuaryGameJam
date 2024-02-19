using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    [SerializeField] bool redKeyCard = false;
    [SerializeField] bool greenKeyCard = false;
    [SerializeField] int samples;
    [SerializeField] Transform hand;

    public bool GetRedCeyKard()
    {
        return redKeyCard;
    }
    public bool GetGreenCard()
    {
        return greenKeyCard;
    }

    public int GetSamples()
    {
        return samples;
    }

    public void SetSamples(int samplesCount)
    {
        samples = samplesCount;
        Debug.Log(samples);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedKeyCard"))
        {
            redKeyCard = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "GreenKeyCard")
        {
            greenKeyCard = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Sample")
        {
            Destroy(other.gameObject);
            SetSamples(GetSamples() + 1);
        }
    }
}
