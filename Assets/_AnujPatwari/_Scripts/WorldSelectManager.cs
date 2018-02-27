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

	PuzzleManager pmw1;
	// Use this for initialization
	void Start () {
		//Need fixed Update to check if the world is complete or not.
		if (pmw1.world1Complete = true) {
			world1State.sprite = w1Complete;
		}
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
