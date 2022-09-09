using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;

    public string[] bestPlayerNames;
    public int[] bestPlayerScores;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadScore();
    }

    public void keepName(string name)
    {
        playerName = name;
    }

    [System.Serializable]
    class SaveData
    {
        public string[] bestPlayerNames;
        public int[] bestPlayerScores;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestPlayerNames = bestPlayerNames;
        data.bestPlayerScores = bestPlayerScores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerNames = data.bestPlayerNames;
            bestPlayerScores = data.bestPlayerScores;
        }
        else
        {
            bestPlayerScores = new int[10];
            bestPlayerNames = new string[10];
        }
    }

    public void AddHighscore(string playerName, int playerScore)
    {
        int[] newBestScore = new int[10];
        string[] newBestPlayer = new string[10];

        bool isAdd = false;
        for (int i = 0; i< 10; i++)
        {
            if (playerScore >= bestPlayerScores[i] && isAdd ==false)
            {
                newBestScore[i] = playerScore;
                newBestPlayer[i] = playerName;

                newBestScore[i + 1] = bestPlayerScores[i];
                newBestPlayer[i+1] = bestPlayerNames[i];
                i++;
                isAdd = true;
            }
            else
            {
                newBestScore[i] = bestPlayerScores[i];
                newBestPlayer[i] = bestPlayerNames[i];
            }
        }
        bestPlayerScores = newBestScore;
        bestPlayerNames = newBestPlayer;
        SaveScore();
    }
        
}
