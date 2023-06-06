using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private float flashLength = 0f;
    
    private bool flashActive;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            else if (flashCounter > flashLength * .82f)
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            else if (flashCounter > flashLength * .66f)
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            else if (flashCounter > flashLength * .49f)
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            else if (flashCounter > flashLength * .33f)
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            else if (flashCounter > flashLength * .16f)
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            else if (flashCounter > 0)
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        flashActive = true;
        flashCounter = flashLength;
        if (currentHealth <= 0)
        {
            string etag = gameObject.tag;
            Destroy(gameObject);
            FindObjectOfType<PlayerController>().LevelUp();
            if (etag == "FinalBoss")
                FindObjectOfType<VictoryMenuController>().Victory();
        }
    }
}
