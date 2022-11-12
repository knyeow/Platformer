using UnityEngine;
using System.IO;  //operating system when we want to work with the files
using System.Runtime.Serialization.Formatters.Binary; //acces to binary formatter


public static class SaveSystem 
{
 
    public static void SavePlayer (GameMaster gameMaster) { 
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameMaster);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
  
    }

}
