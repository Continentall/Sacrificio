using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    private PlayerController playerC;
    
    void Start()
    {
        playerC = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "FinalBoss")
        {
            EnemyHealthManager eHM;
            eHM = other.gameObject.GetComponent<EnemyHealthManager>();
            eHM.HurtEnemy(damage);
            playerC.HitTarget();
        }
    }
}
