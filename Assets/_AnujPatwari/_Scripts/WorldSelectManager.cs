using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldSelectManager : MonoBehaviour {

	[SerializeField]
	Sprite w1Complete, w1Incomplete, w2Complete, w2Incomplete, w3Complete, w3Incomplete, w4Complete, w4Incomplete;

	[SerializeField]
	Image world1State, world2State, world3State, world4State;

	GlobalGameManager ggm;
	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();

	}
	
	void Update () {

		if (ggm.worldsComplete > 0) {
			world1State.sprite = w1Complete;
		} else {
			world1State.sprite = w1Incomplete;
		}
		if (ggm.worldsComplete > 1) {
			world2State.sprite = w2Complete;
		} else {
			world2State.sprite = w2Incomplete;
		}
		if (ggm.worldsComplete > 2) {
			world3State.sprite = w3Complete;
		} else {
			world3State.sprite = w3Incomplete;
		}
		if (ggm.worldsComplete > 3) { 
			world4State.sprite = w4Complete; 
		} else {
			world4State.sprite = w4Incomplete;
		}
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void Level1()
	{
		SceneManager.LoadScene ("World1LevelSelect");
	}
		
}
