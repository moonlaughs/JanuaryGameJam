using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints;
    [SerializeField] float maxHealth;
    [SerializeField] float minHealth;

    /*    public float GetMaxHealth()
        {
            return maxHealth;
        }

        public float GetMinHealth() 
        {
            return minHealth;
        }

        public float GetHealthPoints()
        { 
            return healthPoints;
        }*/

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
            Destroy(gameObject);
        }
    }

    public void heal()
    { 
        
    }
}
