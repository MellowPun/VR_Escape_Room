using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void SavePlayer(GameObject player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.savingStation";
        FileStream stream = new FileStream(path, FileMode.CreateNew);

        DataSaving data= new DataSaving(player);
        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static DataSaving LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.savingStation";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataSaving data = formatter.Deserialize(stream) as DataSaving;
            stream.Close() ;
            return data;

        }
        else
        {
            Debug.Log("Save file not found");
            return null;
        }
    }

}
