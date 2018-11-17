using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;


    public class JQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Value { get; set; }
        public string Clue { get; set; }
        public bool isDouble { get; set; }
    }

    public class JGameData
    {
        

        public int Row { get; set; }
        public int Column { get; set; }
        public List<string> Category { get; set; }
        public List<List<JQuestion>> Question { get; set; }

        public void ResumeData()
        {
            GameData.SetSize(Row, Column);
            GameData.Question = Question;
            GameData.Category = Category;
        }
        
        public override string ToString()
        {
            return JsonMapper.ToJson(this);
        }
        
    }
    

    public static class GameData
    {
        public static int Row { get; private set; }
        public static int Column { get; private set; }
        public static List<string> Category { get; set; }
        public static List<List<JQuestion>> Question { get; set; }


        static GameData()
        {
            SetSize(6,5);
            Debug.Log(GetInstance());
        }

        public static JGameData GetInstance()
        {
            return new JGameData
            {
                Row = GameData.Row,
                Column = GameData.Column,
                Category = GameData.Category,
                Question = GameData.Question
            };
        }
       
        private static void Init()
        {
            Category.Clear();
            for (int i = 0; i < Column; i++)
            {
                Category.Add("");
            }
            
            Question.Clear();
            for (int i = 0; i < Column; i++)
            {
                var qset = new List<JQuestion>();
                for (int j = 0; j < Row; j++)
                {
                    qset.Add(new JQuestion());
                }
                Question.Add(qset);
                
            }
        }
        
        public static void SetSize(int col, int row)
        {
            Category = new List<string>();
            Question = new List<List<JQuestion>>();
            Row = row;
            Column = col;
            Init();
        }
        

    }
    