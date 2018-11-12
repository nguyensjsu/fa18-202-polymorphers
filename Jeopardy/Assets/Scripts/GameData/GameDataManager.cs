using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LitJson;
using UnityEngine;

namespace GameData
{
    public static class GameDataManager
    {
        private static string mFolderName;
        private static string mFileName;
 
        private static string FileName { get { return Path.Combine(FolderName, mFileName);} }
        private static string FolderName { get { return Path.Combine(Application.persistentDataPath, mFolderName); } }

        public static void Init(string pFolderName, string pFileName) {
            mFolderName = pFolderName;
            mFileName = pFileName;
            Read();
        }
        
        private static void Read() {
            if(!Directory.Exists(FolderName)) {
                Directory.CreateDirectory(FolderName);
            }
            if(File.Exists(FileName)) {
                FileStream fs = new FileStream(FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                JsonData values = JsonMapper.ToObject(sr.ReadToEnd());

                if (values.Keys.Contains("Row") && values.Keys.Contains("Column"))
                {
                    GameData.SetSize((int)values["Row"], (int)values["Column"]);
                }

                if (values.Keys.Contains("Catagory"))
                {
                    for (int i = 0; i < UPPER; i++)
                    {
                        
                    }
                    GameData
                }
                foreach(var key in values.Keys) {
                    Dic_Value.Add(key, values[key].ToString());
                }
                
                
                if(fs != null) {
                    fs.Close();
                }
                if(sr != null) {
                    sr.Close();
                }
            }
        }
        

        private static void Save() {
            string values = JsonMapper.ToJson(GameData.);
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
        
        public static bool HasKey(string pKey) {
            return Dic_Value.ContainsKey(pKey);
        }

        //读取string值
        public static string GetString(string pKey) {
            if(HasKey(pKey)) {
                return Dic_Value[pKey];
            } else {
                return string.Empty;
            }
        }

        //保存string值
        public static void SetString(string pKey, string pValue) {
            if(HasKey(pKey)) {
                Dic_Value[pKey] = pValue;
            } else {
                Dic_Value.Add(pKey, pValue);
            }
            Save();
        }


    }
}