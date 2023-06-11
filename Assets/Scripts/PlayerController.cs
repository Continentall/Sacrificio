using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    [SerializeField] private float speed = 0f;
    [SerializeField] private AudioSource audioSourceSteps;
    [SerializeField] private AudioSource audioSourceAttack;
    [SerializeField] private AudioSource audioSourceAttackHit;
    [SerializeField] private PetController pet;
    [SerializeField] private float attackTime = .50f;
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private Text playerLevelText;

    private float attackCounter = .50f;
    private bool isAttacking;
    private bool isMoving = false;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSourceSteps = GetComponent<AudioSource>();
        animator.SetFloat("lastMoveX", 0);
        animator.SetFloat("lastMoveY", -1);
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.fixedDeltaTime;
        animator.SetFloat("moveX", body.velocity.x);
        animator.SetFloat("moveY", body.velocity.y);

        if (!isMoving)
        {
            if (body.velocity.x != 0 || body.velocity.y != 0)
            {
                isMoving = true;
                audioSourceSteps.Play();
            }
        }
        else
        {
            if (body.velocity.x == 0 && body.velocity.y == 0)
            {
                isMoving = false;
                audioSourceSteps.Stop();
            }
        }

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void Update()
    {
        if(isAttacking)
        {
            body.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
                audioSourceAttack.Stop();
            }
        }
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
            audioSourceAttack.Play();
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
        FindObjectOfType<HealthManager>().CurrentHealth = data.Health;
        Vector3 position;
        position.x = data.Position[0];
        position.y = data.Position[1];
        position.z = data.Position[2];
        transform.position = position;
        CameraController cc = FindObjectOfType<CameraController>();
        Vector2 miposition;
        Vector2 maposition;
        miposition.x = data.MinCamPosition[0];
        miposition.y = data.MinCamPosition[1];

        maposition.x = data.MaxCamPosition[0];
        maposition.y = data.MaxCamPosition[1];

        cc.MinPosition = miposition;
        cc.MaxPosition = maposition;
    }

    public void HitTarget()
    {
        audioSourceAttackHit.Play();
    }

    public int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel = value; }
    }

    public void LevelUp()
    {
        playerLevel++;
        playerLevelText.text = $"Уровень: {playerLevel}"; 
    }
}
