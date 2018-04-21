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

	void Start(){
		ggm = FindObjectOfType<GlobalGameManager> ();
	}

	void Update(){
		if (currentIndex == 4 && t.enabled == false) {
			t.enabled = true;
			ggm.WorldCompleted (worldNum);
			StartCoroutine (LevelCompleted ());
		}
	}

	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator LevelCompleted ()
	{
		ggm.Save ();
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("World1LevelSelect");
	}
}
