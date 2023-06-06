using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PetData
{
    [SerializeField] private float[] petPosition;

    public PetData(PetController pet)
    {
        petPosition = new float[3];
        petPosition[0] = pet.transform.position.x;
        petPosition[1] = pet.transform.position.y;
        petPosition[2] = pet.transform.position.z;

    }

    public float[] PetPosition 
    {
        get { return petPosition; } 
        set { petPosition = value; } 
    }
}
