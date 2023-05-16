using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField]
    private Animator myAnim;
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float maxRange = 5f;
    [SerializeField]
    private float minRange = 0f;


    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
            FollowPlayer();
    }
    
    public void FollowPlayer()
    {
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));

        myAnim.SetFloat("lastMoveX", myAnim.GetFloat("moveX"));
        myAnim.SetFloat("lastMoveY", myAnim.GetFloat("moveY"));
    }
}
