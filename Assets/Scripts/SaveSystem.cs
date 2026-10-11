using UnityEngine;
using System.IO;
using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveData.fish";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/SaveData.fish";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            
            return data;
        }
        else
        {
            Debug.Log("save file not found in " + path);
            return null;
        }
    }

    public static void DestroySave()
    {
        File.Delete(Application.persistentDataPath + "/SaveData.fish");
    }
}
