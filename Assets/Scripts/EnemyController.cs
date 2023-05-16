using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[SerializeField]
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Animator myAnim;
    [SerializeField]
    private Transform target;
    [SerializeField]
    public Transform homePos;
    public AIDestinationSetter aiDs;

    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        aiDs = GetComponent<AIDestinationSetter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            FollowPlayer();
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
            Evade();
    }
    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        if (aiDs)
            aiDs.target = target;
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void Evade()
    {
        myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, 2 * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
            myAnim.SetBool("isMoving", false);
        if (aiDs)
            aiDs.target = homePos;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Damage")
        {
            Vector2 diff = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + diff.x * 0.5f, transform.position.y + diff.y * 0.5f);
        }
    }
} 
