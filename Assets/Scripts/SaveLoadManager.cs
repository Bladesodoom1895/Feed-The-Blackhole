using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFilePath;

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/savedata.json";
    }

    public void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved");
    }

    public SaveData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game Loaded");
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found");
            return null;
        }
    }
}
