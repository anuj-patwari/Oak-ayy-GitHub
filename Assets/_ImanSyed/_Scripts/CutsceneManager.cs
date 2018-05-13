using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class CutsceneManager : MonoBehaviour {

	[SerializeField]
	string sceneToLoad;

	bool canTap;

	GlobalGameManager ggm;

	void Start(){
		ggm = FindObjectOfType<GlobalGameManager> ();
		ggm.as2.mute = true;
		InvokeRepeating ("checkFrame", 0.5f, 0.5f);
		Invoke ("CanTap", 4);
	}

	void Update () {
		if (Input.GetMouseButton (0) && canTap) {
			ggm.as2.mute = false;
			SceneManager.LoadScene (sceneToLoad);
		}
	}

	void checkFrame(){
		if (GetComponent<VideoPlayer> ().frame == (long)GetComponent<VideoPlayer> ().frameCount) {
			ggm.as1.volume = 0;
			ggm.as2.mute = false;
			SceneManager.LoadScene (sceneToLoad);
		}
	}

	void CanTap(){
		canTap = true;
	}

}
