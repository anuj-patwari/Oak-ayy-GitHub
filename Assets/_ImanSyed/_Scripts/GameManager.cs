using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;

	[SerializeField]
	string mainMenuScene;

	public IEnumerator RestartAfter (float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void RestartInstant(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {

			if (gameIsPaused) {
				Resume ();
			} else 
			{
				Pause ();
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void Pause()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene (mainMenuScene);
	}
}
