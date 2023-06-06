using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseGameMenu;

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Victory()
    {
        pauseGameMenu.SetActive(true); 
        Time.timeScale = 0f;
    }
}
