using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField]
	Slider slide;

	Camera cam;

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;

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
		pos.x = slide.value;
		cam.transform.position = pos;
	}

	public void DisableScroll(){
		slide.gameObject.SetActive (false);
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

}
