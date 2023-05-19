using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("Progress loaded");
        FindObjectOfType<PlayerController>().LoadPlayer();
        FindObjectOfType<PetController>().LoadPet();
    }
}
