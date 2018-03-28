using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour {

	public static GlobalGameManager ggm;

	public short worldsComplete = 0;
	public float worldLevels = 0;



	[SerializeField]
	AudioSource as1, as2;

	[SerializeField]
	AudioClip clip1, clip2, clip3, clip4, clip5, clip6;

	bool changeMusic1 = true, changeMusic2;

	//Stars Collections from each level
	public int stars1_1, stars1_2, stars1_3, stars1_4, stars2_1, stars2_2, stars2_3, stars2_4, stars3_1, stars3_2, stars3_3, stars3_4, stars4_1, stars4_2, stars4_3, stars4_4;
	//Total stars collected
	public int starCount;
	//Stars collected in current level
	public int currStars;



	void Awake() {
		if (ggm == null) {
			DontDestroyOnLoad (gameObject);
			ggm = this;
		} else if (ggm != this) {
			Destroy (gameObject);
		}
	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.Delete)) {
			if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
				File.Delete (Application.persistentDataPath + "/playerInfo.dat");
			}
		}
		if (Input.GetKeyDown (KeyCode.Tab)) {
			changeMusic2 = true;
			changeMusic1 = false;
		}
		if (changeMusic1) {
			if (as2.volume < 1) {
				as1.volume -= 0.0035f;
				as2.volume += 0.0035f;
			} else {
				changeMusic1 = false;
			}
		}
		if (changeMusic2) {
			if (as1.volume < 1) {
				as2.volume -= 0.0035f;
				as1.volume += 0.0035f;
			} else {
				changeMusic2 = false;
			}
		}
	}


	public void MusicChange(short sceneNumber){
		if (as1.volume == 1) {
			changeMusic1 = true;
			switch (sceneNumber) {
			case 4:
				as2.clip = clip4;
				break;
			case 6:
				as2.clip = clip6;
				break;
			}
		}
		else{
			changeMusic2 = true;
			switch (sceneNumber) {
			case 3:
				as1.clip = clip3;
				break;
			case 5:
				as1.clip = clip5;
				break;
			}
		}
	}

	public void WorldCompleted(short worldNum)
	{
		if (worldNum > worldsComplete) {
			worldsComplete = worldNum;
			ggm.Save ();
		}
	}

	public void LevelCompleted(float levelNumber)
	{
		if (levelNumber > worldLevels) {
			worldLevels = levelNumber;
			ggm.Save ();
		}
	}

	public void StarsUpdate()
	{
		starCount = stars1_1 + stars1_2 + stars1_3 + stars1_4 + stars2_1 + stars2_2 + stars2_3 + stars2_4 + stars3_1 + stars3_2 + stars3_3 + stars3_4 + stars4_1 + stars4_2 + stars4_3 + stars4_4;
		ggm.Save ();
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.worldsComplete = worldsComplete;
		data.levelsComplete = worldLevels;
		data.stars1_1 = stars1_1;
		data.stars1_2 = stars1_2;
		data.stars1_3 = stars1_3;
		data.stars1_4 = stars1_4;
		data.stars2_1 = stars2_1;
		data.stars2_2 = stars2_2;
		data.stars2_3 = stars2_3;
		data.stars2_4 = stars2_4;
		data.stars3_1 = stars3_1;
		data.stars3_2 = stars3_2;
		data.stars3_3 = stars3_3;
		data.stars3_4 = stars3_4;
		data.stars4_1 = stars4_1;
		data.stars4_2 = stars4_2;
		data.stars4_3 = stars4_3;
		data.stars4_4 = stars4_4;
		data.starCount = starCount;

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
			stars1_1 = data.stars1_1;
			stars1_2 = data.stars1_2;
			stars1_3 = data.stars1_3;
			stars1_4 = data.stars1_4;
			stars2_1 = data.stars2_1;
			stars2_2 = data.stars2_2;
			stars2_3 = data.stars2_3;
			stars2_4 = data.stars2_4;
			stars3_1 = data.stars3_1;
			stars3_2 = data.stars3_2;
			stars3_3 = data.stars3_3;
			stars3_4 = data.stars3_4;
			stars4_1 = data.stars4_1;
			stars4_2 = data.stars4_2;
			stars4_3 = data.stars4_3;
			stars4_4 = data.stars4_4;
			starCount = data.starCount;
		}
	}

	public void NewGame ()
	{
			worldsComplete = 0;
			worldLevels = 1;
			stars1_1 = 0;
			stars1_2 = 0;
			stars1_3 = 0;
			stars1_4 = 0;
			stars2_1 = 0;
			stars2_2 = 0;
			stars2_3 = 0;
			stars2_4 = 0;
			stars3_1 = 0;
			stars3_2 = 0;
			stars3_3 = 0;
			stars3_4 = 0;
			stars4_1 = 0;
			stars4_2 = 0;
			stars4_3 = 0;
			stars4_4 = 0;
			starCount = 0;

		Save ();
		SceneManager.LoadScene ("WorldSelect");

	}
}



[Serializable]
class PlayerData{
	public short worldsComplete;
	public float levelsComplete;
	public int stars1_1, stars1_2, stars1_3, stars1_4, stars2_1, stars2_2, stars2_3, stars2_4, stars3_1, stars3_2, stars3_3, stars3_4, stars4_1, stars4_2, stars4_3, stars4_4, starCount;
}