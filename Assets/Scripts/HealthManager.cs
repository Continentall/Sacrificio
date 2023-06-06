using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int m_currentHealth = 60;
    [SerializeField] private int m_maxHealth = 100;
    [SerializeField] private GameObject defeatGameMenu;
    [SerializeField] private float flashLength = 0f;
    
    private bool flashActive;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damegeToGive)
    {
        m_currentHealth -= damegeToGive;
        flashActive = true;
        flashCounter = flashLength;
        if (m_currentHealth <= 0) 
        {
            gameObject.SetActive(false);
            defeatGameMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void AddHealth(int hp)
    {
        m_currentHealth += hp;
        if (m_currentHealth > m_maxHealth)
            m_currentHealth = m_maxHealth;
    }

    public int CurrentHealth
    {
        get
        { 
            return m_currentHealth;
        }
        set 
        { 
            m_currentHealth = value;
        }
        
    }

    public int MaxHealth
    {
        get 
        { 
            return m_maxHealth;
        }
        set 
        { 
            m_maxHealth = value; 
        }
    }
    public bool IsFullHealth()
    {
        return m_currentHealth == m_maxHealth;
    }
}
