using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;

	string mainMenuScene, mainMenuPlay;

	[SerializeField]
	Object mainMenu, playGame;

	[SerializeField]
	Sprite toggleSoundSprite, toggleOrigSoundSprite;

	[SerializeField]
	Image soundToggleButton;


	void Start ()
	{
		mainMenuScene = mainMenu.name;
		mainMenuPlay = playGame.name;
		toggleOrigSoundSprite = soundToggleButton.sprite;
	}

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
		Time.timeScale = 1f;
		SceneManager.LoadScene (mainMenuScene);
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void toggleSoundSpriteFn()
	{
		if (soundToggleButton.sprite == toggleOrigSoundSprite) {
			//when sound is on
			soundToggleButton.sprite = toggleSoundSprite;
		} else {
			//when sound is off
			soundToggleButton.sprite = toggleOrigSoundSprite;
		}
	}

	public void MainMenuPlayButton()
	{
		SceneManager.LoadScene (mainMenuPlay);
	}

}
