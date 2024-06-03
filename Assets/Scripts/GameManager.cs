using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int resources;
    public int[] upgrades; // Example: upgrade levels for various items

    private SaveLoadManager saveLoadManager;

    void Start()
    {
        saveLoadManager = FindAnyObjectByType<SaveLoadManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    void SaveGame()
    {
        SaveData data = new SaveData();
        data.score = score;
        data.resources = resources;
        data.upgrades = upgrades;

        saveLoadManager.SaveGame(data);
    }

    void LoadGame()
    {
        SaveData data = saveLoadManager.LoadGame();
        if (data != null)
        {
            score = data.score;
            resources = data.resources;
            upgrades = data.upgrades;
        }
    }
}
