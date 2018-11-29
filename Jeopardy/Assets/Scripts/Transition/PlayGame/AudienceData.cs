using System;
namespace Model
{
    public class AudienceData
    {

        private static AudienceData uniqueInstance;
        //private string redTeamName;
        //private string blueTeamName;
        private int redScore;
        private int blueScore;

        private int redIndex;
        private int blueIndex;
        private string[] redTeams;
        private string[] blueTeams;


        private AudienceData()
        {

        }

        public static AudienceData GetInstance()
        {
            if(uniqueInstance == null)
            {
                uniqueInstance = new AudienceData();
            }
            return uniqueInstance;
        }

        public void SetTeamInformation(string[] redTeam, string[] blueTeam)
        {
            this.redTeams = redTeam;
            this.blueTeams = blueTeam;
        }

        public void SetTeamsIndex(int redIndex, int blueIndex)
        {
            this.redIndex = redIndex;
            this.blueIndex = blueIndex;
        }

        public void SetTeamsScore(int redScore, int blueScore)
        {
            this.redScore = redScore;
            this.blueScore = blueScore;
        }

        public string GetRedTeamName()
        {
            return redTeams[redIndex];
        }

        public string GetBlueTeamName()
        {
            return blueTeams[blueIndex];
        }

        public int GetRedScore()
        {
            return redScore;
        }

        public int GetBlueScore()
        {
            return blueScore;
        }

        public string[] GetRedTeams()
        {
            return redTeams;
        }

        public string[] GetBlueTeams()
        {
            return blueTeams;
        }

        public int GetCurrentRedIndex()
        {
            return redIndex;
        }

        public int GetCurrentBlueIndex()
        {
            return blueIndex;
        }
    }
}
