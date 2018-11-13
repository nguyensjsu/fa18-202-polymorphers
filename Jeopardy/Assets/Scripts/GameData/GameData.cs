using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.PlayerLoop;

namespace GameData
{

    public struct JQuestion
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
        
        public JGameData GetInstance()
        {
            return new JGameData
            {
                Row = GameData.Row,
                Column = GameData.Column,
                Category = GameData.Category,
                Question = GameData.Question
            };
        }

        public void ResumeData()
        {
            GameData.SetSize(Row, Column);
            GameData.Question = Question;
            GameData.Category = Category;
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
            SetSize(5,5);
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
        
        public static void SetSize(int row, int col)
        {
            Category = new List<string>();
            Question = new List<List<JQuestion>>();
            Row = row;
            Column = col;
            Init();
        }

    }
}