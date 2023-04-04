using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField]
    private int Damage = 10;
    [SerializeField]
    private float AttackSpeed = 2f;
    private HealthManager HealthMan;
    private float WaitToHurt = 0f;
    private bool IsTouching;
    

    // Start is called before the first frame update
    void Start()
    {
        WaitToHurt = AttackSpeed;
        HealthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouching)
        {
            WaitToHurt -= Time.deltaTime;
            if (WaitToHurt <= 0)
            {
                HealthMan.HurtPlayer(Damage);
                WaitToHurt = AttackSpeed;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            HealthMan.HurtPlayer(Damage);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
            IsTouching = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            IsTouching = false;
            WaitToHurt = AttackSpeed;
        }
    }
}
