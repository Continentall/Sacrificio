using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager HealthMan;
    public Slider HealthBar;
    public Text HpText;
    // Start is called before the first frame update
    void Start()
    {
        HealthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.maxValue = HealthMan.maxHealth;
        HealthBar.value = HealthMan.currentHealth;
        HpText.text = $"{HealthMan.currentHealth}/{HealthMan.maxHealth}";
    }
}
