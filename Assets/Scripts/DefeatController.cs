using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DefeatController : MonoBehaviour
{
    public GameObject defeatGameMenu;


    public void ResumeGame()
    {
        defeatGameMenu.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        defeatGameMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
