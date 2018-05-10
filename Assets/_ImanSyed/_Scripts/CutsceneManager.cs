using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutsceneManager : MonoBehaviour {

	[SerializeField]
	string sceneToLoad;

	void Update () {
		if (Input.GetMouseButton (0)) {
			SceneManager.LoadScene (sceneToLoad);
		}
	}
}
