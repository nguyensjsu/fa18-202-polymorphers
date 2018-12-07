using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

public static class GameDataTest
{
    private static string SubFolderName = "Save";
    private static string SaveFileName = "Test.json";

    private static string FileName { get { return Path.Combine(FolderName, SaveFileName); } }
    private static string FolderName { get { return Path.Combine(Application.persistentDataPath, SubFolderName); } }

    public static int DemoCount()
    {
        return 2;
    }

    public static List<string> DemoName()
    {
        List<string> li = new List<string>();
        li.Add("DESIGN PATTERN");
        li.Add("TEST GAME");
        return li;
    }

    public static void TestInitDemo(string gameName)
    {
        if(gameName == "DESIGN PATTERN")
        {
            SaveFileName = "Test.json";
        }
        else if(gameName == "TEST GAME")
        {
            SaveFileName = "TestGame";
        }
        Debug.Log(FileName);
        Debug.Log(FolderName);

        if (!Directory.Exists(FolderName))
        {
            Directory.CreateDirectory(FolderName);
        }

        if (File.Exists(FileName))
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            JsonData data = JsonMapper.ToObject(sr.ReadToEnd());
            int row = (int)data["Row"];
            int col = (int)data["Column"];
            GameData.Init(col, row);

            GameData.BlueTeam = JsonMapper.ToObject<List<string>>(data["BlueTeam"].ToJson());
            GameData.RedTeam = JsonMapper.ToObject<List<string>>(data["RedTeam"].ToJson());

            GameData.Category = JsonMapper.ToObject<List<JCategory>>(data["Category"].ToJson());
            GameData.DoubleCategory = JsonMapper.ToObject<List<JCategory>>(data["DoubleCategory"].ToJson());
            GameData.Question = JsonMapper.ToObject<List<List<JQuestion>>>(data["Question"].ToJson());
            GameData.DoubleQuestion = JsonMapper.ToObject<List<List<JQuestion>>>(data["DoubleQuestion"].ToJson());

            GameData.FinalCategory = JsonMapper.ToObject<JCategory>(data["FinalCategory"].ToJson());
            GameData.FinalQuestion = JsonMapper.ToObject<JQuestion>(data["FinalQuestion"].ToJson());

            fs.Close();
            sr.Close();
        }
    }
}