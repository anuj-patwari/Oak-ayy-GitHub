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

	// Use this for initialization
	void Start () {

		toggleOrigSoundSprite = soundToggleButton.sprite;

	}
	
	// Update is called once per frame
	void Update () {
		
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
		SceneManager.LoadScene ("Level 1");
	}
}
