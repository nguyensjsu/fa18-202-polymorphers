using System.Collections;

    public void BlueButtonClick()

        scoreInput.text = GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text;

    public void QuestionButtonClick()
        //string lineIndex = currentButtonName.Substring((currentButtonName.Length) - 2, 1);
        //int line = System.Int32.Parse(lineIndex);
        //string rowIndex = currentButtonName.Substring((currentButtonName.Length) - 1, 1);
        //int row = System.Int32.Parse(rowIndex);

        audienceObject.SendMessage("changePanel", "3");

    //set score screen event

    public void ExitScoreScreenButtonClick()
        scoreInput.text = "";
        Debug.Log(TotalTime);