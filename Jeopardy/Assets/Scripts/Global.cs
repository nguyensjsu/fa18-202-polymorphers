using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;

public class Global : MonoBehaviour {

	void Start ()
	{
		GameDataManager.Init("savedata", "save");
		GameDataManager.InitDemo();
	}

	public void SaveData()
	{
		GameDataManager.SaveData();
	}

	public void LoadData()
	{
		GameDataManager.LoadData();
	}
}
