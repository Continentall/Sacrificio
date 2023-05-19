using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public int level;
    public float health;
    public float[] position;
    public float[] minCamPosition;
    public float[] maxCamPosition;
    public float[] positionPet;

    public PlayerData(PlayerController pc, HealthManager hm, CameraController cc)
    {
        //level = player.level;
        health = hm.currentHealth;
        position = new float[3];
        position[0] = pc.transform.position.x;
        position[1] = pc.transform.position.y;
        position[2] = pc.transform.position.z;
        minCamPosition = new float[2];
        maxCamPosition = new float[2];
        minCamPosition[0] = cc.minPosition.x;
        minCamPosition[1] = cc.minPosition.y;

        maxCamPosition[0] = cc.maxPosition.x;
        maxCamPosition[1] = cc.maxPosition.y;
    }

    
}
