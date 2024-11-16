using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager INSTANCE;

    public string userName;
    public string highScoreUserName;
    public int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (INSTANCE != null)
        {
            Destroy(this);
        }
        else
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Serializable]
    public class SavedData
    {
        public string highScoreUserName;
        public int highScore;
        public string lastUserName;
    }

    public void Save()
    {
        SavedData data = new SavedData();
        data.highScoreUserName = highScoreUserName;
        data.lastUserName = userName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);
            highScoreUserName = data.highScoreUserName;
            userName = data.lastUserName;
            highScore = data.highScore;
        }
    }
}
