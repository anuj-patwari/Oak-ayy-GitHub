using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {

	[SerializeField]
	Slider cameraSlide;

	Camera cam;

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;

	public GameObject loadingScreen;
	public Slider slider;
	public Text progressText;

	void Start(){
		cam = Camera.main;
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

	public void CameraScroll(){
		Vector3 pos = Vector3.zero;
		pos.z = cam.transform.position.z;
		pos.x = cameraSlide.value;
		cam.transform.position = pos;
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

	public void RestartInstant(){
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

	}
}
