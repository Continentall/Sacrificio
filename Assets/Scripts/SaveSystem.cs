using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SavePlayer(PlayerController pc, HealthManager hm, CameraController cc)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.scrfc";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(pc, hm, cc);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Progress saved");
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/save.scrfc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Continue");
            return data;
        }
        else
        {
            Debug.Log("Start new game");
            return null;
        }
    }
}
