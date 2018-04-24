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

	public bool canStart = true, tutorial1Skipped, tutorial2Skipped, muted;

	public AudioSource as1, as2;

	[SerializeField]
	AudioClip musicMenu, music1, music2, music3, music4, music5;

	[SerializeField]
	AudioClip gameOverSoundEffect, clickSoundEffect, starSoundEffect;

	public GameObject tutorialParent;

	bool changeMusic1, changeMusic2;

	//Stars Collections from each level
	public int stars1_1, stars1_2, stars1_3,  stars1_4, stars2_1, stars2_2, stars2_3, stars2_4, stars2_5, stars2_6, stars3_1, stars3_2, stars3_3, stars3_4, stars3_5, stars3_6, stars3_7, stars3_8, stars4_1, stars4_2, stars4_3, stars4_4, stars4_5, stars4_6, stars4_7, stars4_8, stars4_9, stars4_10;
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
		if (SceneManager.GetActiveScene ().name == "MainMenu" || SceneManager.GetActiveScene ().name == "WorldSelect") {
			as2.Play ();
		} else {
			as1.Play ();
		}

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update(){

		if (SceneManager.GetActiveScene ().name == "1.1") {

			if (tutorialParent == null) {
				tutorialParent = GameObject.FindGameObjectWithTag ("Tutorial");
			}
			if (!tutorial1Skipped) {
				FindObjectOfType<SceneManagerScript> ().skipButton.SetActive (true);
				tutorialParent.GetComponent<Animator> ().enabled = true;
				canStart = false;
			} else {
				tutorialParent.SetActive (false);
			}
		} else if (SceneManager.GetActiveScene ().name == "2.1") {
			if (tutorialParent == null) {
				tutorialParent = GameObject.FindGameObjectWithTag ("Tutorial");
			}
			if (!tutorial2Skipped) {
				FindObjectOfType<SceneManagerScript> ().skipButton.SetActive (true);
				tutorialParent.GetComponent<Animator> ().enabled = true;
				canStart = false;
			} else {
				tutorialParent.SetActive (false);
			}
		}

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

	public void MusicChange(int sceneNumber){
		if (as1.volume == 1) {
			changeMusic1 = true;

		}
		else{
			changeMusic2 = true;
			switch (sceneNumber) {
			case 1:
				as1.clip = music1;
				break;
			case 11:
				as1.clip = music3;
				break;
			case 5:
				as1.clip = music2;
				break;
			case 19:
				as1.clip = music4;
				break;
			}
			as1.Play ();
		}
	}

	public void PlaySoundEffect(int whichEffect){
		switch (whichEffect) {
		case 1:
			as1.PlayOneShot (gameOverSoundEffect);
			break;
		case 2: 
			as1.PlayOneShot (clickSoundEffect);
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

		data.muted = muted;
		data.tutorial1Skipped = tutorial1Skipped;
		data.tutorial2Skipped = tutorial2Skipped;
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

			muted = data.muted;
			tutorial1Skipped = data.tutorial1Skipped;
			tutorial2Skipped = data.tutorial2Skipped;
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
		tutorial1Skipped = false;
		tutorial2Skipped = false;
		worldsComplete = 0;
		worldLevels = 1;
		stars1_1 = stars1_2 = stars1_3 = stars1_4 = stars2_1 = stars2_2 = stars2_3 = stars2_4 = stars2_5 = stars2_6 = stars3_1 = stars3_2 = stars3_3 = stars3_4 = stars3_5 = stars3_6 = stars3_7 = stars3_8 = stars4_1 = stars4_2 = stars4_3 = stars4_4 = stars4_5 = stars4_6 = stars4_7 = stars4_8 = stars4_9 = stars4_10 = starCount = 0;
		Save ();
		SceneManager.LoadScene ("WorldSelect");

	}

	public void hax()
	{
		worldsComplete = 10;
		worldLevels = 10;
	}
}


[Serializable]
class PlayerData{
	public bool tutorial1Skipped, tutorial2Skipped, muted;
	public short worldsComplete;
	public float levelsComplete;
	public int stars1_1, stars1_2, stars1_3, stars1_4, stars2_1, stars2_2, stars2_3, stars2_4, stars2_5, stars2_6, stars3_1, stars3_2, stars3_3, stars3_4, stars3_5, stars3_6, stars3_7, stars3_8, stars4_1, stars4_2, stars4_3, stars4_4, stars4_5, stars4_6, stars4_7, stars4_8, stars4_9, stars4_10, starCount;
}