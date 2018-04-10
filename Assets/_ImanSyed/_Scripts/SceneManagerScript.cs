using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {

	[SerializeField]
	Slider cameraSlide;

	[SerializeField]
	int myLevelNumber;

	[SerializeField]
	GameObject camButtons;


	public GameObject skipButton;

	Camera cam;

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;

	[SerializeField]
	GameObject pauseButton, retryButton;

	public GameObject loadingScreen;
	public Slider slider;
	public Text progressText;

	GlobalGameManager ggm;

	[SerializeField]
	GameObject restartUI;


	//Level Complete Popup
	[SerializeField]
	GameObject star1, star2, star3, levelCompPopup, levelCompPopupBackground;
	PortalScript portScr;

	void Start(){
		cam = Camera.main;
		ggm = FindObjectOfType<GlobalGameManager> ();
		portScr = FindObjectOfType<PortalScript> ();
		ggm.currStars = 0;
		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);
		levelCompPopup.SetActive (false);

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

	public void CameraScroll(bool vertical){
		Vector3 pos = cam.transform.position;
		if (vertical) {
			pos.y = cameraSlide.value;
			cam.transform.position = pos;
		}
		else{
			pos.x = cameraSlide.value;
			cam.transform.position = pos;
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive (false);
		levelCompPopupBackground.SetActive (false);
		Time.timeScale = 1f;
		gameIsPaused = false;
		pauseButton.SetActive (true);
		retryButton.SetActive (true);
	}

	public void Pause()
	{
		pauseMenuUI.SetActive (true);
		levelCompPopupBackground.SetActive (true);
		Time.timeScale = 0f;
		gameIsPaused = true;
		pauseButton.SetActive (false);
		retryButton.SetActive (false);
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public IEnumerator RestartAfter (float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void ShowRestartUI()
	{
		Time.timeScale = 0f;
		restartUI.SetActive (true);
	}

	public void HideRestartUI()
	{
		restartUI.SetActive (false);
		Time.timeScale = 1f;
	}

	public void RestartInstant(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}


	public void LoadLevel (int sceneIndex)
	{
		StartCoroutine (LoadAsynchronously (sceneIndex));

	}

	IEnumerator LoadAsynchronously (int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		loadingScreen.SetActive (true);

		while (!operation.isDone) 
		{
			float progress = Mathf.Clamp01 (operation.progress / .9f);

			slider.value = progress;
			progressText.text = Mathf.Round(progress * 100f) + "%";

			yield return null;
		}
	}

	public void DisableScroll()
	{
		cameraSlide.gameObject.SetActive (false);
		camButtons.SetActive (false);
	}

	public void SkipTutorial()
	{

		if (myLevelNumber == 1) {
			ggm.tutorial1Skipped = true;
		} else if (myLevelNumber == 5) {
			ggm.tutorial2Skipped = true;
		}
		ggm.canStart = true;
		skipButton.SetActive (false);
		ggm.tutorialParent.SetActive (false);

		ggm.Save ();


	}

	public void StarsCollected()
	{
		switch (myLevelNumber) {
		case 1:
			if (ggm.currStars > ggm.stars1_1) {
				ggm.stars1_1 = ggm.currStars;
			}
			break;

		case 2:
			if (ggm.currStars > ggm.stars1_2) {
				ggm.stars1_2 = ggm.currStars;
			}
			break;

		case 3:
			if (ggm.currStars > ggm.stars1_3) {
				ggm.stars1_3 = ggm.currStars;
			}
			break;

		case 4:
			if (ggm.currStars > ggm.stars1_4) {
				ggm.stars1_4 = ggm.currStars;
			}
			break;

		case 5:
			if (ggm.currStars > ggm.stars2_1) {
				ggm.stars2_1 = ggm.currStars;
			}
			break;

		case 6:
			if (ggm.currStars > ggm.stars2_2) {
				ggm.stars2_2 = ggm.currStars;
			}
			break;

		case 7:
			if (ggm.currStars > ggm.stars2_3) {
				ggm.stars2_3 = ggm.currStars;
			}
			break;

		case 8:
			if (ggm.currStars > ggm.stars2_4) {
				ggm.stars2_4 = ggm.currStars;
			}
			break;

		case 9:
			if (ggm.currStars > ggm.stars2_5) {
				ggm.stars2_5 = ggm.currStars;
			}
			break;

		case 10:
			if (ggm.currStars > ggm.stars2_6) {
				ggm.stars2_6 = ggm.currStars;
			}
			break;

		case 11:
			if (ggm.currStars > ggm.stars3_1) {
				ggm.stars3_1 = ggm.currStars;
			}
			break;

		case 12:
			if (ggm.currStars > ggm.stars3_2) {
				ggm.stars3_2 = ggm.currStars;
			}
			break;

		case 13:
			if (ggm.currStars > ggm.stars3_3) {
				ggm.stars3_3 = ggm.currStars;
			}
			break;

		case 14:
			if (ggm.currStars > ggm.stars3_4) {
				ggm.stars3_4 = ggm.currStars;
			}
			break;

		case 15:
			if (ggm.currStars > ggm.stars3_5) {
				ggm.stars3_5 = ggm.currStars;
			}
			break;

		case 16:
			if (ggm.currStars > ggm.stars3_6) {
				ggm.stars3_6 = ggm.currStars;
			}
			break;

		case 17:
			if (ggm.currStars > ggm.stars3_7) {
				ggm.stars3_7 = ggm.currStars;
			}
			break;

		case 18:
			if (ggm.currStars > ggm.stars3_8) {
				ggm.stars3_8 = ggm.currStars;
			}
			break;

		case 19:
			if (ggm.currStars > ggm.stars4_1) {
				ggm.stars4_1 = ggm.currStars;
			}
			break;

		case 20:
			if (ggm.currStars > ggm.stars4_2) {
				ggm.stars4_2 = ggm.currStars;
			}
			break;

		case 21:
			if (ggm.currStars > ggm.stars4_3) {
				ggm.stars4_3 = ggm.currStars;
			}
			break;

		case 22:
			if (ggm.currStars > ggm.stars4_4) {
				ggm.stars4_4 = ggm.currStars;
			}
			break;

		case 23:
			if (ggm.currStars > ggm.stars4_5) {
				ggm.stars4_5 = ggm.currStars;
			}
			break;

		case 24:
			if (ggm.currStars > ggm.stars4_6) {
				ggm.stars4_6 = ggm.currStars;
			}
			break;

		case 25:
			if (ggm.currStars > ggm.stars4_7) {
				ggm.stars4_7 = ggm.currStars;
			}
			break;

		case 26:
			if (ggm.currStars > ggm.stars4_8) {
				ggm.stars4_8 = ggm.currStars;
			}
			break;

		case 27:
			if (ggm.currStars > ggm.stars4_9) {
				ggm.stars4_9 = ggm.currStars;
			}
			break;

		case 28:
			if (ggm.currStars > ggm.stars4_10) {
				ggm.stars4_10 = ggm.currStars;
			}
			break;
		}
	}

	public void LevelCompletePopup()
	{
		levelCompPopup.SetActive (true);
		levelCompPopupBackground.SetActive (true);
		pauseButton.SetActive (false);
		retryButton.SetActive (false);
		if (ggm.currStars > 0) 
		{
			star1.SetActive (true);
		}
		if (ggm.currStars > 1) 
		{
			star3.SetActive (true);
		}
		if (ggm.currStars > 2) 
		{
			star2.SetActive (true);
		}

	}

	public void NextLvl()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (portScr.levelToLoad);
	}

	public void GoToWorldSelect()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("WorldSelect");
	}
}
