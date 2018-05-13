using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayManager : MonoBehaviour {

	[SerializeField]
	GameObject p2, p3, p4, p5, p6, p7;

	[SerializeField]
	GameObject nextButton, prevButton;

	int count = 0;

	[SerializeField]
	GameObject screenTransition;


	void Update()
	{/*
		if (!nextButton.activeSelf && !prevButton.activeSelf && count > 0) {

			nextButton.SetActive (true); 
			prevButton.SetActive (true);

		} else if (nextButton.activeSelf && prevButton.activeSelf && count == 0) {

			nextButton.SetActive (false); 
			prevButton.SetActive (false);

		}*/

	}
	public void NextPage()
	{
		switch (count) {

		case 0:
			prevButton.SetActive (true);
			p2.SetActive (true);
			count++;
			break;

		case 1:
			p2.SetActive (false);
			p3.SetActive (true);
			count++;
			break;

		case 2:
			p3.SetActive (false);
			p4.SetActive (true);
			count++;
			break;

		case 3:
			p4.SetActive (false);
			p5.SetActive (true);
			count++;
			break;

		case 4:
			p5.SetActive (false);
			p6.SetActive (true);
			count++;
			break;

		case 5:
			p6.SetActive (false);
			p7.SetActive (true);
			nextButton.SetActive (false);
			count++;
			break;

		default:
			count = 0;
			p6.SetActive (false);
			break;
		}


	}
	public void PrevPage()
	{

		switch (count) {


		case 1:
			prevButton.SetActive (false);
			p2.SetActive (false);
			count--;
			break;

		case 2:
			p2.SetActive (true);
			p3.SetActive (false);
			count--;
			break;

		case 3:
			p3.SetActive (true);
			p4.SetActive (false);
			count--;
			break;

		case 4:
			p4.SetActive (true);
			p5.SetActive (false);
			count--;
			break;

		case 5:
			p5.SetActive (true);
			p6.SetActive (false);
			count--;
			break;

		case 6:
			nextButton.SetActive (true);
			p6.SetActive (true);
			p7.SetActive (false);
			count--;
			break;

		}


	}


	public void BackToMainMenu()
	{
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		StartCoroutine (MainMenuFn (1));
	}

	IEnumerator MainMenuFn(float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene ("MainMenu");
	}
}
