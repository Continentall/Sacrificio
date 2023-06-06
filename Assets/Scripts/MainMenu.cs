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

        string pathPlayer = Application.persistentDataPath + "/saveplayer.scrfc";
        
        if (File.Exists(pathPlayer))
            File.Delete(pathPlayer);
        
        string pathPet = Application.persistentDataPath + "/savepet.scrfc";
        
        if (File.Exists(pathPet))
            File.Delete(pathPet);
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
