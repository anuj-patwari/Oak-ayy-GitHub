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

	void Start ()
	{
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			ggm.LevelCompleted (levelNumber);
			SceneManager.LoadScene (levelToLoad);
		}
	}
}
