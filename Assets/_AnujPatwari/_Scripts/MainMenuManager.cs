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
	GameObject newGameUI, screenTransition;

	[SerializeField]
	float playButtonDelay = 1;

	[SerializeField]
	float soundToggleDelay = 0.2f;

	[SerializeField]
	GameObject tapToStartButton, playButton, leftPanel;

	GlobalGameManager ggm;

	bool canTap;

	void Awake(){
		GlobalGameManager.ggm.Load ();
	}

	void Start () 
	{
		StartCoroutine (tapToStart (2));
		screenTransition.SetActive (true);
		ggm = FindObjectOfType<GlobalGameManager> ();
		toggleOrigSoundSprite = soundToggleButton.sprite;
		if (ggm.as1.mute) {
			soundToggleButton.sprite = toggleSoundSprite;
		}
		else if (ggm.muted) {
			toggleSoundSpriteFn ();
		}
		Invoke ("CanTap", 2);

	}

	void Update()
	{
		if (Input.GetMouseButton(0) && canTap) {
			//MainMenuPlayButton ();
			tapToStartButton.SetActive(false);
			playButton.SetActive (true);
			leftPanel.SetActive (true);
			ggm.PlaySoundEffect (2);
		}
	}

	void CanTap(){
		canTap = true;
	}

	public void toggleSoundSpriteFn()
	{
		StartCoroutine(toggleSound());
	}

	IEnumerator toggleSound()
	{
		yield return new WaitForSeconds (soundToggleDelay);
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

	public void ImageURLButton(){
		Application.OpenURL ("https://i.imgur.com/ponUrMV.png");
	}



	public void MainMenuPlayButton()
	{
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		ggm.PlaySoundEffect (2);
		StartCoroutine(MainMenuPlayButtonFn());
	}

	IEnumerator MainMenuPlayButtonFn()
	{
		yield return new WaitForSeconds (playButtonDelay);
		SceneManager.LoadScene ("Cutscene1");
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

	public void loadCredits()
	{
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		StartCoroutine (loadCreditsFn (1));
	}

	IEnumerator loadCreditsFn(float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene ("Credits");
	}
		

	IEnumerator tapToStart(float delay)
	{
		yield return new WaitForSeconds (delay);
		tapToStartButton.SetActive (true);
	}
}
