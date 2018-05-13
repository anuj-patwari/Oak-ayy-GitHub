﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {


	public string levelToLoad;

	[SerializeField]
	float levelNumber;

	[SerializeField]
	bool worldCompleted;

	GlobalGameManager ggm;
	SceneManagerScript sms;

	void Start ()
	{
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();
		sms = FindObjectOfType<SceneManagerScript> ();
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			Time.timeScale = 0f;
			ggm.LevelCompleted (levelNumber);
			sms.LevelCompletePopup ();
			sms.StarsCollected ();
			ggm.StarsUpdate ();
			if (worldCompleted == true) 
			{
				if (ggm.worldsComplete == 0) 
				{
					ggm.worldsComplete = 1;
					ggm.Save ();
				}

				if (ggm.worldsComplete == 1) 
				{
					ggm.worldsComplete = 2;
					ggm.Save ();
				}

				if (ggm.worldsComplete == 2) 
				{
					ggm.worldsComplete = 3;
					ggm.Save ();
				}

				if (ggm.worldsComplete == 3) 
				{
					ggm.worldsComplete = 4;
					ggm.Save ();
				}
			}
		}
	}
}
