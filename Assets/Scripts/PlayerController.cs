using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    [SerializeField]
    private float speed = 0f;

    private float attackTime = .50f;
    private float attackCounter = .50f;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
        animator.SetFloat("moveX", body.velocity.x);
        animator.SetFloat("moveY", body.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
         
        if(isAttacking)
        {
            body.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, FindObjectOfType<HealthManager>(), FindObjectOfType<CameraController>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null)
            return;
        // level = data.level;
        FindObjectOfType<HealthManager>().currentHealth = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        CameraController cc = FindObjectOfType<CameraController>();
        Vector2 miposition;
        Vector2 maposition;
        miposition.x = data.minCamPosition[0];
        miposition.y = data.minCamPosition[1];

        maposition.x = data.maxCamPosition[0];
        maposition.y = data.maxCamPosition[1];

        cc.minPosition = miposition;
        cc.maxPosition = maposition;
    }
}
