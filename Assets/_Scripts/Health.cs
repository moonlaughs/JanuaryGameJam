using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints;
    [SerializeField] float maxHealth;
    [SerializeField] float minHealth;

    private void Start()
    {
        healthPoints = maxHealth;
    }
    void Update()
    {
        
    }

    public void damageDeal(int damage)
    { 
        healthPoints -= damage;
        if (healthPoints <= minHealth)
        {
            if (gameObject.tag == "Player")
            {
                Destroy(gameObject);
                SceneManager.LoadScene(4);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }
}
