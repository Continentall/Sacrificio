using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    //Player save system
    public static void SavePlayer(PlayerController pc, HealthManager hm, CameraController cc)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveplayer.scrfc";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(pc, hm, cc);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Progress saved");
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/saveplayer.scrfc";
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
            Debug.Log("Start new game cause (player do not exists)");
            return null;
        }
    }

    //Pet save system
    public static void SavePet(PetController pet)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savepet.scrfc";
        FileStream stream = new FileStream(path, FileMode.Create);

        PetData data = new PetData(pet);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Progress saved");
    }

    public static PetData LoadPet()
    {
        string path = Application.persistentDataPath + "/savepet.scrfc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PetData data = formatter.Deserialize(stream) as PetData;
            stream.Close();
            Debug.Log("Continue");
            return data;
        }
        else
        {
            Debug.Log("Start new game cause (pet do not exists)");
            return null;
        }
    }
}
