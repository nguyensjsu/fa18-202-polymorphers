using System.Collections.Generic;
using System.IO;
//using LitJson;
using UnityEngine;

    public static class GameDataManager
    {
        private static string mFolderName;
        private static string mFileName;
 
        private static string FileName { get { return Path.Combine(FolderName, mFileName);} }
        private static string FolderName { get { return Path.Combine(Application.persistentDataPath, mFolderName); } }

        public static void InitDemo()
        {
            GameData.SetSize(6, 5);
            for (int i = 0; i < GameData.Column; i++)
            {
                GameData.Category[i] = "Test Category";
                for (int j = 0; j < GameData.Row; j++)
                {
                    GameData.Question[i][j].Question = "";
                    GameData.Question[i][j].Question = "Test Question";
                    GameData.Question[i][j].Answer = "Test Answer";
                    GameData.Question[i][j].Clue = "Test Clue";
                    GameData.Question[i][j].Value = j * 200 + 100;
                    GameData.Question[i][j].isDouble = false;
                }
            }
        }
        
        public static void Init(string pFolderName, string pFileName) {
            mFolderName = pFolderName;
            mFileName = pFileName;
            Debug.Log(FileName);
            Debug.Log(FolderName);
            InitDemo();
            Debug.Log(GameData.GetInstance());
//            ReadData();
        }
        
        public static void LoadData() {
            
            if(!Directory.Exists(FolderName)) {
                Directory.CreateDirectory(FolderName);
            }
            
            if(File.Exists(FileName)) {
                FileStream fs = new FileStream(FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                //JGameData data = JsonMapper.ToObject<JGameData>(sr.ReadToEnd());
                //data.ResumeData();
                if(fs != null) {
                    fs.Close();
                }
                if(sr != null) {
                    sr.Close();
                }
            }
        }
        
        public static void SaveData() {
            Dictionary<string, object> gamedata = new Dictionary<string, object>();
            foreach (var info in typeof(GameData).GetProperties())
            {
                gamedata.Add(info.Name, info.GetValue(null, null));
            }
            
            //string values = JsonMapper.ToJson(gamedata);
            if(!Directory.Exists(FolderName)) {
                Directory.CreateDirectory(FolderName);
            }
            //Debug.Log(values);
            
            FileStream file = new FileStream(FileName, FileMode.Create);
            //byte[] bts = System.Text.Encoding.UTF8.GetBytes(values);
            //file.Write(bts,0,bts.Length);
            if(file != null) {
                file.Close();
            }
        }
    }