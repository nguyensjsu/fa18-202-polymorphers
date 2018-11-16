using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager instance;

    public GameObject character;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public bool IsSaveFile()
    {
        print(Application.persistentDataPath);
        print(Directory.Exists(Application.persistentDataPath + "/game_save"));
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }

        if (!Directory.Exists(Application.persistentDataPath + "/game_save/character_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/character_data/character_save");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/game_save/character_data/character_save.txt");
        var json = JsonUtility.ToJson(character);
        bf.Serialize(file, json);
        file.Close();
    }
}
