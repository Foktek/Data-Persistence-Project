using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    //public TMP_InputField input;
    public string inputName;
    public string topName;
    public int highScore = 0;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }

    [System.Serializable]
    class SaveData
    {
        public string topName;
        public int highScore;
    }

    public void SaveName(string newTopName, int newHighScore)
    {
        SaveData data = new SaveData();
        data.topName=newTopName;
        data.highScore = newHighScore;

        string json=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("We saved, sir");
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data=JsonUtility.FromJson<SaveData>(json);
            topName = data.topName;
            highScore=data.highScore;
        }
        Debug.Log("We loaded, sir");
    }
}
