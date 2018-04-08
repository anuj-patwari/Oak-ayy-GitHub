using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	[SerializeField]
	Sprite toggleSoundSprite, toggleOrigSoundSprite;

	[SerializeField]
	Image soundToggleButton;

	[SerializeField]
	GameObject newGameUI;

	GlobalGameManager ggm;


	void Awake(){
		GlobalGameManager.ggm.Load ();
	}

	void Start () {
		ggm = FindObjectOfType<GlobalGameManager> ();
		toggleOrigSoundSprite = soundToggleButton.sprite;
	}

	public void toggleSoundSpriteFn()
	{
		if (soundToggleButton.sprite == toggleOrigSoundSprite) {
			//when sound is on
			soundToggleButton.sprite = toggleSoundSprite;
			ggm.as1.mute = true;
			ggm.as2.mute = true;

		} else {
			//when sound is off
			soundToggleButton.sprite = toggleOrigSoundSprite;
			ggm.as1.mute = false;
			ggm.as2.mute = false;
		}
	}

	public void MainMenuPlayButton()
	{
		SceneManager.LoadScene ("WorldSelect");
	}

	public void AppQuit()
	{
		Application.Quit();
	}

	public void ShowNewGameButtonUI()
	{
		newGameUI.SetActive (true);
	}

	public void HideNewGameButtonUI()
	{
		newGameUI.SetActive (false);
	}

	public void NewGame()
	{
		ggm.NewGame ();
	}
}
