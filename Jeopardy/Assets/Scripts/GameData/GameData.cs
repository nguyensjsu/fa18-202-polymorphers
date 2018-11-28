using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.PlayerLoop;
    public class JQuestion
    {
        public string Question;
        public string Answer;
        public int Value;
        public string Clue;
        public bool isDouble;
    }

    public class JGameData
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public List<string> Category { get; set; }
        public List<List<JQuestion>> Question { get; set; }
        public List<List<JQuestion>> DoubleQuestion { get; set; }
        public string FinalCategory { get; set; }
        public string FinalQuestion { get; set; }
        public string FinalAnswer { get; set; }
        
        public JGameData GetInstance()
        {
            return new JGameData
            {
                Row = GameData.Row,
                Column = GameData.Column,
                Category = GameData.Category,
                Question = GameData.Question,
                DoubleQuestion = GameData.DoubleQuestion,
                FinalCategory = GameData.FinalCategory,
                FinalAnswer = GameData.FinalAnswer,
            };
        }

        public void ResumeData()
        {
            GameData.Init(Row, Column);
            GameData.Question = Question;
            GameData.Category = Category;
        }
    }
    

    public static class GameData
    {
//        public static string GameName { get; set; }
        public static int Row { get; private set; }
        public static int Column { get; private set; }
        public static List<string> Category { get; set; }
        public static List<List<JQuestion>> Question { get; set; }
        public static List<List<JQuestion>> DoubleQuestion { get; set; }
        public static List<string> BlueTeam { get; set; }
        public static List<string> RedTeam { get; set; }
        public static string FinalCategory { get; set; }
        public static string FinalQuestion { get; set; }
        public static string FinalAnswer { get; set; }

        static GameData()
        {
            Init(6,5);
        }
       
        public static void Init(int col, int row)
        {
            Row = row;
            Column = col;
            Category = new List<string>();
            Question = new List<List<JQuestion>>();
            DoubleQuestion = new List<List<JQuestion>>();
            BlueTeam = new List<string>();
            RedTeam = new List<string>();
            FinalCategory = "";
            FinalQuestion = "";
            FinalAnswer = "";
            
            for (int i = 0; i < Column; i++)
            {
                Category.Add("");
            }
            
            for (int i = 0; i < 10; i++)
            {
                RedTeam.Add("");
                BlueTeam.Add("");
            }
            
            for (int i = 0; i < Column; i++)
            {
                var qset = new List<JQuestion>();
                for (int j = 0; j < Row; j++)
                {
                    qset.Add(new JQuestion());
                }
                Question.Add(qset);
                
                qset = new List<JQuestion>();
                for (int j = 0; j < Row; j++)
                {
                    qset.Add(new JQuestion());
                }
                DoubleQuestion.Add(qset);
            }

            
        }

    }
    
   