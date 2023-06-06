using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager HealthMan;
    [SerializeField] private Slider HealthBar;
    [SerializeField] private Text HpText;

    void Start()
    {
        HealthMan = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        int max = HealthMan.MaxHealth;
        int current = HealthMan.CurrentHealth;
        HealthBar.maxValue = max;
        HealthBar.value = current;
        HpText.text = $"{current}/{max}";
    }
}
