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

	//public short animationIsPlaying;
	[SerializeField]
	GameObject skipButton;

	public bool canStart = true;

	public AudioSource as1, as2;

	[SerializeField]
	AudioClip musicMenu, music1, music2, music3, music4, music5;

	[SerializeField]
	AudioClip rubberSoundEffect, pipeSoundEffect, starSoundEffect;

	GameObject tutorialParent;

	bool changeMusic1 = true, changeMusic2;

	//Stars Collections from each level
	public int stars1_1, stars1_2, stars1_3, stars1_4, stars2_1, stars2_2, stars2_3, stars2_4, stars2_5, stars2_6, stars3_1, stars3_2, stars3_3, stars3_4, stars3_5, stars3_6, stars3_7, stars3_8, stars4_1, stars4_2, stars4_3, stars4_4, stars4_5, stars4_6, stars4_7, stars4_8, stars4_9, stars4_10;
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
		
		if ((SceneManager.GetActiveScene ().name == "1.1" || SceneManager.GetActiveScene ().name == "2.1") && tutorialParent == null) {
			tutorialParent = GameObject.FindGameObjectWithTag ("Tutorial");
			skipButton.SetActive (true);
			//if (animationIsPlaying == 0) {
			//	animationIsPlaying = 1;
				tutorialParent.GetComponent<Animator> ().enabled = true;
				canStart = false;
		//	} 
		}
		/*if (tutorialParent != null) {
			if (animationIsPlaying == 2) {
		if (tutorialParent != null) {
			if (animationIsPlaying == 3) {

				tutorialParent.SetActive (false);
			} else {
				if(Input.GetMouseButtonDown(0) && animationIsPlaying == 1){
					animationIsPlaying = 2;
				}else if(Input.GetMouseButtonDown(0) && animationIsPlaying == 2){
					animationIsPlaying = 3;
					canStart = true;
					Save ();		
				}
			}
		}*/

		if (Input.GetKeyDown (KeyCode.Delete)) {
			if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
				File.Delete (Application.persistentDataPath + "/playerInfo.dat");
				Debug.Log ("Deleted");
			}
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

	public void SkipTutorial()
	{

		canStart = true;
		skipButton.SetActive (false);
		tutorialParent.SetActive (false);
		Save ();

	}

	public void MusicChange(int sceneNumber){
		if (as1.volume == 1) {
			changeMusic1 = true;
			switch (sceneNumber) {
			case 4:
				as2.clip = music3;
				break;
			case 6:
				as2.clip = music5;
				break;
			}
		}
		else{
			changeMusic2 = true;
			switch (sceneNumber) {
			case 3:
				as1.clip = music2;
				break;
			case 5:
				as1.clip = music4;
				break;
			}
		}
	}

	public void PlaySoundEffect(int whichEffect){
		switch (whichEffect) {
		case 1:
			as1.PlayOneShot (rubberSoundEffect);
			break;
		case 2: 
			as1.PlayOneShot (pipeSoundEffect);
			break;
		case 3:
			as1.PlayOneShot (starSoundEffect);
			break;
		}
	}

	public void WorldCompleted(short worldNum)
	{
		if (worldNum > worldsComplete) {
			worldsComplete = worldNum;
			ggm.Save ();
		}
		MusicChange (SceneManager.GetActiveScene().buildIndex);
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

		//data.animationIsPlaying = animationIsPlaying;
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
		data.stars2_5 = stars2_5;
		data.stars2_6 = stars2_6;
		data.stars3_1 = stars3_1;
		data.stars3_2 = stars3_2;
		data.stars3_3 = stars3_3;
		data.stars3_4 = stars3_4;
		data.stars3_5 = stars3_5;
		data.stars3_6 = stars3_6;
		data.stars3_7 = stars3_7;
		data.stars3_8 = stars3_8;
		data.stars4_1 = stars4_1;
		data.stars4_2 = stars4_2;
		data.stars4_3 = stars4_3;
		data.stars4_4 = stars4_4;
		data.stars4_5 = stars4_5;
		data.stars4_6 = stars4_6;
		data.stars4_7 = stars4_7;
		data.stars4_8 = stars4_8;
		data.stars4_9 = stars4_9;
		data.stars4_10 = stars4_10;
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

			//animationIsPlaying = data.animationIsPlaying;
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
			stars2_5 = data.stars2_5;
			stars2_6 = data.stars2_6;
			stars3_1 = data.stars3_1;
			stars3_2 = data.stars3_2;
			stars3_3 = data.stars3_3;
			stars3_4 = data.stars3_4;
			stars3_5 = data.stars3_5;
			stars3_6 = data.stars3_6;
			stars3_7 = data.stars3_7;
			stars3_8 = data.stars3_8;
			stars4_1 = data.stars4_1;
			stars4_2 = data.stars4_2;
			stars4_3 = data.stars4_3;
			stars4_4 = data.stars4_4;
			stars4_5 = data.stars4_5;
			stars4_6 = data.stars4_6;
			stars4_7 = data.stars4_7;
			stars4_8 = data.stars4_8;
			stars4_9 = data.stars4_9;
			stars4_10 = data.stars4_10;
			starCount = data.starCount;
		}
	}

	public void NewGame ()
	{
		//animationIsPlaying = 0;
		worldsComplete = 0;
		worldLevels = 1;
		stars1_1 = stars1_2 = stars1_3 = stars1_4 = stars2_1 = stars2_2 = stars2_3 = stars2_4 = stars2_5 = stars2_6 = stars3_1 = stars3_2 = stars3_3 = stars3_4 = stars3_5 = stars3_6 = stars3_7 = stars3_8 = stars4_1 = stars4_2 = stars4_3 = stars4_4 = stars4_5 = stars4_6 = stars4_7 = stars4_8 = stars4_9 = stars4_10 = starCount = 0;
		Save ();
		SceneManager.LoadScene ("WorldSelect");

	}
}


[Serializable]
class PlayerData{
	public short animationIsPlaying;
	public short worldsComplete;
	public float levelsComplete;
	public int stars1_1, stars1_2, stars1_3, stars1_4, stars2_1, stars2_2, stars2_3, stars2_4, stars2_5, stars2_6, stars3_1, stars3_2, stars3_3, stars3_4, stars3_5, stars3_6, stars3_7, stars3_8, stars4_1, stars4_2, stars4_3, stars4_4, stars4_5, stars4_6, stars4_7, stars4_8, stars4_9, stars4_10, starCount;
}