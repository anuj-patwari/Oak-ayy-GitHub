using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GlobalGameManager : MonoBehaviour {

	public static GlobalGameManager ggm;

	public short worldsComplete = 0;
	public float worldLevels = 1;

	void Awake() {
		if (ggm == null) {
			DontDestroyOnLoad (gameObject);
			ggm = this;
		} else if (ggm != this) {
			Destroy (gameObject);
		}
	}

	public void WorldCompleted(short worldNum)
	{
		if (worldNum > worldsComplete) {
			worldsComplete = worldNum;
		}
	}

	public void LevelCompleted(float levelNumber)
	{
		if (levelNumber > worldLevels) {
			worldLevels = levelNumber;
		}
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.worldsComplete = worldsComplete;
		data.levelsComplete = worldLevels;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			worldsComplete = data.worldsComplete;
			worldLevels = data.levelsComplete;
		}
	}
}

[Serializable]
class PlayerData{
	public short worldsComplete;
	public float levelsComplete;
}