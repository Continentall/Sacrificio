using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothing;
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;

    void LateUpdate()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

    public Vector2 MaxPosition
    {
        get { return maxPosition; }
        set { maxPosition = value; }
    }
    public Vector2 MinPosition 
    {
        get { return minPosition; } 
        set {  minPosition = value; } 
    }
}
