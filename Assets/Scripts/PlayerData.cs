using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    private int level;
    private int health;
    private float[] position;
    private float[] minCamPosition;
    private float[] maxCamPosition;
    private float[] positionPet;

    public PlayerData(PlayerController pc, HealthManager hm, CameraController cc)
    {
        level = pc.PlayerLevel;
        health = hm.CurrentHealth;
        
        position = new float[3];
        position[0] = pc.transform.position.x;
        position[1] = pc.transform.position.y;
        position[2] = pc.transform.position.z;
        
        minCamPosition = new float[2];
        maxCamPosition = new float[2];
        
        minCamPosition[0] = cc.MinPosition.x;
        minCamPosition[1] = cc.MinPosition.y;

        maxCamPosition[0] = cc.MaxPosition.x;
        maxCamPosition[1] = cc.MaxPosition.y;
    }

    public int Level { get { return level; } set { level = value; } }
    public int Health { get { return health; } set { health = value; } }
    public float[] Position { get { return position; } set { position = value; } }
    public float[] MinCamPosition { get {  return minCamPosition; } set {  minCamPosition = value; } }
    public float[] MaxCamPosition { get { return maxCamPosition; } set {  maxCamPosition = value; } }
    public float[] PositionPet { get { return positionPet; } set { positionPet = value; } }
    
}
