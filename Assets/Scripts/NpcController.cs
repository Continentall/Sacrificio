using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NpcController : MonoBehaviour
{
    [SerializeField] private string npcName;
    [SerializeField] private string speech;
    [SerializeField] private GameObject DialogPage;
    [SerializeField] private Text tname;
    [SerializeField] private Text texts;
    
    private Transform target;
    private float maxRange = 5f;
    private float minRange = 0f;
    private bool isTalking = false;
    
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isTalking)
            {
                isTalking = true;
                DialogPage.SetActive(true);
                tname.text = npcName;
                texts.text = speech;
            }
            else if (isTalking && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E)))
            {
                isTalking = false;
                DialogPage.SetActive(false);
            }
        }
    }
}
