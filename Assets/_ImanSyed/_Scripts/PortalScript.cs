using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalScript : MonoBehaviour {

	[SerializeField]
	string levelName;

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			SceneManager.LoadScene (levelName);
		}
	}

}
