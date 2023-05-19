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
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            StopMoving();
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
            FollowPlayer();
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
    }

    public void StopMoving()
    {
        myAnim.SetBool("isMoving", false);
    }

    public void SavePet()
    {
        SaveSystem.SavePet(this);
    }

    public void LoadPet()
    {
        PetData data = SaveSystem.LoadPet();
        if (data == null)
            return;

        Vector3 positionPet;
        positionPet.x = data.petPosition[0];
        positionPet.y = data.petPosition[1];
        positionPet.z = data.petPosition[2];
        transform.position = positionPet;
    }
}