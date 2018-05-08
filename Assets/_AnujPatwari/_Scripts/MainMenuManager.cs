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

	[SerializeField]
	float delay;

	GlobalGameManager ggm;


	void Awake(){
		GlobalGameManager.ggm.Load ();
	}

	void Start () {
		ggm = FindObjectOfType<GlobalGameManager> ();
		toggleOrigSoundSprite = soundToggleButton.sprite;
		if (ggm.as1.mute) {
			soundToggleButton.sprite = toggleSoundSprite;
		}
		else if (ggm.muted) {
			toggleSoundSpriteFn ();
		}
	}

	public void toggleSoundSpriteFn()
	{
		if (soundToggleButton.sprite == toggleOrigSoundSprite) {
			//when sound is on
			soundToggleButton.sprite = toggleSoundSprite;
			ggm.as1.mute = true;
			ggm.as2.mute = true;
			ggm.muted = true;
			ggm.Save ();

		} else {
			//when sound is off
			soundToggleButton.sprite = toggleOrigSoundSprite;
			ggm.as1.mute = false;
			ggm.as2.mute = false;
			ggm.muted = false;
			ggm.Save ();
		}
	}

	public void MainMenuPlayButton()
	{
		StartCoroutine(MainMenuPlayButtonFn());
	}

	IEnumerator MainMenuPlayButtonFn()
	{
		yield return new WaitForSeconds (delay);
		ggm.PlaySoundEffect (2);
		SceneManager.LoadScene ("WorldSelect");
	}

	public void AppQuit()
	{
		ggm.PlaySoundEffect (2);
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
		ggm.PlaySoundEffect (2);
		ggm.NewGame ();
	}
}
