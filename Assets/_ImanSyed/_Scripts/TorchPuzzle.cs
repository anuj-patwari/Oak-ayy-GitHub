using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TorchPuzzle : MonoBehaviour {
	public short currentIndex = 0;



	[SerializeField]
	Text t;

	short worldNum = 3;

	GlobalGameManager ggm;

	bool completed;

	float lerp = 0;

	[SerializeField]
	GameObject planet, screenTransition;

	void Start(){
		ggm = FindObjectOfType<GlobalGameManager> ();
		//completed = true;
	}

	void Update(){
		if (currentIndex == 4 && t.enabled == false) {
			t.enabled = true;
			ggm.WorldCompleted (worldNum);
			completed = true;
			//StartCoroutine (LevelCompleted ());
		}
		if (completed) {
			lerp = Mathf.Lerp (lerp, 1, 0.0025f);
			planet.GetComponent<MeshRenderer> ().material.SetFloat ("_Blend", lerp);
			Debug.Log ("ssss");
		}
	}

	public void Restart(){
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		StartCoroutine (RestartFn (1));
	}

	IEnumerator RestartFn(float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}



	public void MainMenu()
	{
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		StartCoroutine (MainMenuFn (1));
	}

	IEnumerator MainMenuFn(float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene ("MainMenu");
	}




	IEnumerator LevelCompleted ()
	{
		ggm.Save ();
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("World1LevelSelect");
	}
}
