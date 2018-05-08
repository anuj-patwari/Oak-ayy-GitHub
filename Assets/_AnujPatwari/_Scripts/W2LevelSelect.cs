using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class W2LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button,level5Button, level6Button, miniGameButton;

	GlobalGameManager ggm;

	//Stars
	[SerializeField]
	GameObject l1s1, l1s2, l1s3, l2s1, l2s2, l2s3, l3s1, l3s2, l3s3, l4s1, l4s2, l4s3, l5s1, l5s2, l5s3, l6s1, l6s2, l6s3;

	//Star Back
	[SerializeField]
	GameObject l2StarBack, l3StarBack, l4StarBack, l5StarBack, l6StarBack;


	[SerializeField]
	GameObject lock2, lock3, lock4, lock5, lock6, mainLock, screenTransition;

	[SerializeField]
	GameObject[] connectors;


	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();

		if (ggm.stars2_1 >= 1) {

			l1s1.SetActive (true);
		}

		if (ggm.stars2_1 >= 2) {

			l1s2.SetActive (true);
		}

		if (ggm.stars2_1 >= 3) {

			l1s3.SetActive (true);
		}
		if (ggm.stars2_2 >= 1) {

			l2s1.SetActive (true);
		}

		if (ggm.stars2_2 >= 2) {

			l2s2.SetActive (true);
		}

		if (ggm.stars2_2 >= 3) {

			l2s3.SetActive (true);
		}

		if (ggm.stars2_3 >= 1) {

			l3s1.SetActive (true);
		}

		if (ggm.stars2_3 >= 2) {

			l3s2.SetActive (true);
		}

		if (ggm.stars2_3 >= 3) {

			l3s3.SetActive (true);
		}

		if (ggm.stars2_4 >= 1) {

			l4s1.SetActive (true);
		}

		if (ggm.stars2_4 >= 2) {

			l4s2.SetActive (true);
		}

		if (ggm.stars2_4 >= 3) {

			l4s3.SetActive (true);
		}

		if (ggm.stars2_5 >= 1) {

			l5s1.SetActive (true);
		}

		if (ggm.stars2_5 >= 2) {

			l5s2.SetActive (true);
		}

		if (ggm.stars2_5 >= 3) {

			l5s3.SetActive (true);
		}

		if (ggm.stars2_6 >= 1) {

			l6s1.SetActive (true);
		}

		if (ggm.stars2_6 >= 2) {

			l6s2.SetActive (true);
		}

		if (ggm.stars2_6 >= 3) {

			l6s3.SetActive (true);
		}
	}

	void Update () {
		if (ggm.worldLevels >= 2.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
			lock2.SetActive (false);
			l2StarBack.SetActive (true);
			if (ggm.worldLevels > 2.2) {
				if (connectors [0].GetComponent<Image> ().fillAmount < 1) {
					connectors [0].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [0].GetComponent<Image> ().fillAmount < 1) {
					connectors [0].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 2.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
			lock3.SetActive (false);
			l3StarBack.SetActive (true);
			if (ggm.worldLevels > 2.3) {
				if (connectors [1].GetComponent<Image> ().fillAmount < 1) {
					connectors [1].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [1].GetComponent<Image> ().fillAmount < 1) {
					connectors [1].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 2.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
			lock4.SetActive (false);
			l4StarBack.SetActive (true);
			if (ggm.worldLevels > 2.4) {
				if (connectors [2].GetComponent<Image> ().fillAmount < 1) {
					connectors [2].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [2].GetComponent<Image> ().fillAmount < 1) {
					connectors [2].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 2.4f)
		{
			level5Button.GetComponent<Button> ().interactable = true;
			lock5.SetActive (false);
			l5StarBack.SetActive (true);
			if (ggm.worldLevels > 2.5) {
				if (connectors [3].GetComponent<Image> ().fillAmount < 1) {
					connectors [3].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [3].GetComponent<Image> ().fillAmount < 1) {
					connectors [3].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 2.5f)
		{
			level6Button.GetComponent<Button> ().interactable = true;
			lock6.SetActive (false);
			l6StarBack.SetActive (true);
			if (ggm.worldLevels > 2.6) {
				if (connectors [4].GetComponent<Image> ().fillAmount < 1) {
					connectors [4].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [4].GetComponent<Image> ().fillAmount < 1) {
					connectors [4].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 2.6f)
		{
			miniGameButton.GetComponent<Button> ().interactable = true;
			mainLock.SetActive (false);
		}
	}

	public void GoToLevel(string sceneName)
	{
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		StartCoroutine (Go (sceneName));
	}

	IEnumerator Go(string scene){
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (scene);
	}
}
