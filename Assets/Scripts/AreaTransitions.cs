using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    [SerializeField] private Vector2 newMinPos;
    [SerializeField] private Vector2 newMaxPos;
    [SerializeField] private Vector3 movePlayer;

    private CameraController cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            cam.MinPosition = newMinPos;
            cam.MaxPosition = newMaxPos;
            other.transform.position += movePlayer;
        }
    }
}
