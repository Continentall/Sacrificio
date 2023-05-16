using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public void ConinueGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayNewGame()
    {
        SceneManager.LoadScene("SampleScene");

        string path = Application.persistentDataPath + "/save.scrfc";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
