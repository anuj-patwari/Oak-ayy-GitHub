using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {


	public string levelToLoad;

	[SerializeField]
	float levelNumber;

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
		}
	}
}
