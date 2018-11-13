using System;
using System.Collections.Generic;
using LitJson;
using

namespace GameData
{
    [TestFixture]
    public class GameDataTest
    {
        [Test]
        public void Test1()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    JQuestion q = new JQuestion();
                    q.Question = "Test Question";
                    q.Answer = "Test Answer";
                    q.Clue = "Test Clue";
                    q.Value = i * 100 + 100;
                    q.isDouble = false;
                    GameData.SetQuestion(i,j,q);
                }
            }
            Dictionary<String, Object> data = new Dictionary<string, object>();
            foreach (var info in typeof(GameData).GetProperties())
            {
                data.Add(info.Name, info.GetValue(null, null));
            }
            
            Console.WriteLine(JsonMapper.ToJson(data));
            GameDataManager.SaveData();
        }    
    }
}