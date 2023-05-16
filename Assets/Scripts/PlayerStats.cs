using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerLevel = 1;
    public int maxLevel = 80;
    public int exp;
    public Text levelText;
    public int baseExp = 10;
    public int[] expToLevelUp;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + playerLevel;
        expToLevelUp = new int[maxLevel];
        for (int i = 0; i < expToLevelUp.Length; i++)
        {
            expToLevelUp[i] = baseExp * i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
