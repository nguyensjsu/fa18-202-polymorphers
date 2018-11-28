using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

    public static class GameDataManager
    {
        private static string SubFolderName = "Save";
        private static string SaveFileName = "Test.json";
 
        private static string FileName { get { return Path.Combine(FolderName, SaveFileName);} }
        private static string FolderName { get { return Path.Combine(Application.persistentDataPath, SubFolderName); } }

        public static void InitDemo()
        {
            GameData.Init(6, 5);
            for (int i = 0; i < 6; i++)
            {
                GameData.Category[i] = "Test Category";
                for (int j = 0; j < 5; j++)
                {
                    GameData.Question[i][j].Question = "Test Question";
                    GameData.Question[i][j].Answer = "Test Answer";
                    GameData.Question[i][j].Clue = "Test Clue";
                    GameData.Question[i][j].Value = i * 100 + 100;
                    GameData.Question[i][j].isDouble = false;
                    
                    GameData.DoubleQuestion[i][j].Question = "Test Question";
                    GameData.DoubleQuestion[i][j].Answer = "Test Answer";
                    GameData.DoubleQuestion[i][j].Clue = "Test Clue";
                    GameData.DoubleQuestion[i][j].Value = i * 100 + 100;
                    GameData.DoubleQuestion[i][j].isDouble = false;
                }
            }
           
        }
        
        public static void LoadData() {
            Debug.Log(FileName);
            Debug.Log(FolderName);

            if(!Directory.Exists(FolderName)) {
                Directory.CreateDirectory(FolderName);
            }
            
            if(File.Exists(FileName)) {
                FileStream fs = new FileStream(FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                JsonData data = JsonMapper.ToObject(sr.ReadToEnd());
                int row = (int) data["Row"];
                int col = (int) data["Column"];
                GameData.Init(col, row);
                
                GameData.Category = JsonMapper.ToObject<List<string>>(data["Category"].ToJson());
                GameData.BlueTeam = JsonMapper.ToObject<List<string>>(data["BlueTeam"].ToJson());
                GameData.RedTeam = JsonMapper.ToObject<List<string>>(data["RedTeam"].ToJson());

                GameData.Question = JsonMapper.ToObject<List<List<JQuestion>>>(data["Question"].ToJson());
                GameData.DoubleQuestion = JsonMapper.ToObject<List<List<JQuestion>>>(data["DoubleQuestion"].ToJson());
 
                GameData.FinalCategory = data["FinalCategory"].ToString();
                GameData.FinalQuestion = data["FinalQuestion"].ToString();
                GameData.FinalAnswer = data["FinalAnswer"].ToString();
                
                fs.Close();
                sr.Close();
            }
   
        }
        
        public static void SaveData() {
            Dictionary<string, object> gamedata = new Dictionary<string, object>();
            foreach (var info in typeof(GameData).GetProperties())
            {
                gamedata.Add(info.Name, info.GetValue(null, null));
            }
            
            string values = JsonMapper.ToJson(gamedata);
            Debug.Log(values);
            
            if(!Directory.Exists(FolderName)) {
                Directory.CreateDirectory(FolderName);
            }
            
            
            FileStream file = new FileStream(FileName, FileMode.Create);
            byte[] bts = System.Text.Encoding.UTF8.GetBytes(values);
            file.Write(bts,0,bts.Length);
            if(file != null) {
                file.Close();
            }
        }
    }