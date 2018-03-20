using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {

	[SerializeField]
	string levelToLoad;

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
			ggm.LevelCompleted (levelNumber);
			SceneManager.LoadScene (levelToLoad);
			sms.StarsCollected ();
			ggm.StarsUpdate ();
		}
	}
}
