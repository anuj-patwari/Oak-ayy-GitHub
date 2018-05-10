using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PollutionPuzzle : MonoBehaviour {

	public short closeCount = 0;

	[SerializeField]
	Text t;

	short worldNum = 4;

	[SerializeField]
	GameObject screenTransition;

	[SerializeField]
	string sceneToLoad;

	GlobalGameManager ggm;

	void Start(){
		ggm = FindObjectOfType<GlobalGameManager> ();
	}
	
	void Update () {
		if (closeCount == 4 && t.enabled == false) {
			t.enabled = true;
			ggm.WorldCompleted (worldNum);
			StartCoroutine (LevelCompleted ());
		}
	}

	public void Restart()
	{
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
		StartCoroutine(MainMenuFn(1));
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
		SceneManager.LoadScene (sceneToLoad);
	}
}
