using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int damegeToGive)
    {
        currentHealth -= damegeToGive;
        if (currentHealth <= 0) 
        {
            gameObject.SetActive(false);
        }
    }
}
