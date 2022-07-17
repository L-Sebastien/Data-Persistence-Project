using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    [HideInInspector]
    public string userName;
    [HideInInspector]
    public int userScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUserNames();

    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int userScore;

    }

    public void SaveUserName(string userName, int userScore)
    {
        SaveData data = new SaveData();
        data.userName = userName;
        data.userScore = userScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserNames()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
            userScore = data.userScore;
            Debug.Log("Reading file in " + path);
        }
        else
        {
            Debug.Log("No file");

        }
    }
}


