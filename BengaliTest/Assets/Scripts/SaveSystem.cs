using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private const string saveFileName = "PlayerData.json";
    public static SaveSystem instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SaveScore(int score)
    {
        PlayerData data = new PlayerData();
        data.totalScore = score;

        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, saveFileName);

        File.WriteAllText(path, json);

        Debug.Log($"Score saved to {path}");
    }

    public int LoadScore()
    {
        string path = Path.Combine(Application.persistentDataPath, saveFileName);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log($"Score loaded from {path}");
            return data.totalScore;
        }
        else
        {
            Debug.Log("No save file found, returning 0");
            SaveScore(0);
            return 0;
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public int totalScore;
}