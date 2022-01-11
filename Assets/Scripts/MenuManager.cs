using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MenuManager : MonoBehaviour
{



    public static MenuManager Instance;
    
    public string playerName;
    public int HScore;
    public string HplayerName;




    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScoreAndName();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScorePlayer;
    }

    public void SaveHighScoreAndName()
    {
        SaveData data = new SaveData();
        data.HighScore = MenuManager.Instance.HScore;
        data.HighScorePlayer = MenuManager.Instance.HplayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreAndName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MenuManager.Instance.HScore = data.HighScore;
            MenuManager.Instance.HplayerName = data.HighScorePlayer;
        }
    }
}
