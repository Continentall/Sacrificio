using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointController : MonoBehaviour
{
    [SerializeField] private int hpToGive = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HealthManager hm;
            hm = other.gameObject.GetComponent<HealthManager>();
            if (!hm.IsFullHealth())
            {
                hm.AddHealth(hpToGive);
                Destroy(gameObject);
            }
        }
    }
}
