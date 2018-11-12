using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.PlayerLoop;

namespace GameData
{

    public struct JQuestion
    {
        string Question;
        string Answer;
        int Value;
        string Clue;
        bool isDouble;
    }

    public static class GameData
    {
        private static int Row { get; private set; }
        private static int Column { get; private set; }
        private static List<string> Catagory;
        private static List<List<JQuestion>> Question;
        
        public static void SetSize(int row, int col)
        {
            Row = row;
            Column = col;
            Init();
        }
        
        private static void Init()
        {
            Catagory.Clear();
            for (int i = 0; i < Column; i++)
            {
                Catagory.Add("");
            }
            
            Question.Clear();
            for (int i = 0; i < Column; i++)
            {
                var qset = new List<JQuestion>();
                for (int j = 0; j < Row; j++)
                {
                    qset.Add(new JQuestion());
                }
                
            }
        }  

        public static JQuestion GetQuestion(int row, int col)
        {
            return Question[row][col];
        }
        
        public static void SetQuestion(int row, int col, JQuestion question)
        {
            Question[row][col] = question;
        }

    }
}