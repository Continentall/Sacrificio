using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealthManager eHM;
            eHM = other.gameObject.GetComponent<EnemyHealthManager>();
            eHM.HurtEnemy(damage);
             
        }
    }
}
