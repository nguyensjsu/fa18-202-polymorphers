using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class Global : MonoBehaviour{
	
	
	private void Awake()
	{
		GameDataManager.Init("savedata", "save");
		GameDataManager.InitDemo();
		Debug.Log(JsonMapper.ToJson(GameData.GetInstance()));
	}

	public static void SaveData()
	{
		GameDataManager.SaveData();
	}

	public static void LoadData()
	{
		GameDataManager.LoadData();
	}
}
