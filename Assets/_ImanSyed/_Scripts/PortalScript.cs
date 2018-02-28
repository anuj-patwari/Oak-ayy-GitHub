using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalScript : MonoBehaviour {

	[SerializeField]
	string levelName;

	[SerializeField]
	int levelNumber;

	GlobalGameManager ggm;

	void Start ()
	{
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			if (ggm.world1levels == levelNumber) {
				ggm.World1Level ();
			}
			SceneManager.LoadScene (levelName);
		}
	}

}
