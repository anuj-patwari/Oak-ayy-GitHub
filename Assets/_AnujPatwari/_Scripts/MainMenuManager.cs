﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	[SerializeField]
	Sprite toggleSoundSprite, toggleOrigSoundSprite;

	[SerializeField]
	Image soundToggleButton;

	// Use this for initialization
	void Start () {

		toggleOrigSoundSprite = soundToggleButton.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;

	}

	public void toggleSoundSpriteFn()
	{
		if (soundToggleButton.sprite == toggleOrigSoundSprite) {
			//when sound is on
			soundToggleButton.sprite = toggleSoundSprite;
			GetComponent<AudioSource> ().mute = true;
		} else {
			//when sound is off
			soundToggleButton.sprite = toggleOrigSoundSprite;
			GetComponent<AudioSource> ().mute = false;
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
}
