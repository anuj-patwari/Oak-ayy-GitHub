using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class W3LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button, level5Button, level6Button, level7Button, level8Button, miniGameButton;

	GlobalGameManager ggm;

	//Stars
	[SerializeField]
	GameObject l1s1, l1s2, l1s3, l2s1, l2s2, l2s3, l3s1, l3s2, l3s3, l4s1, l4s2, l4s3, l5s1, l5s2, l5s3, l6s1, l6s2, l6s3, l7s1, l7s2, l7s3, l8s1, l8s2, l8s3;

	//Star Back
	[SerializeField]
	GameObject l2StarBack, l3StarBack, l4StarBack, l5StarBack, l6StarBack, l7StarBack, l8StarBack;


	[SerializeField]
	GameObject lock2, lock3, lock4, lock5, lock6, lock7, lock8, mainLock;

	[SerializeField]
	GameObject[] connectors;

	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();

		if (ggm.stars3_1 >= 1) {

			l1s1.SetActive (true);
		}

		if (ggm.stars3_1 >= 2) {

			l1s2.SetActive (true);
		}

		if (ggm.stars3_1 >= 3) {

			l1s3.SetActive (true);
		}
		if (ggm.stars3_2 >= 1) {

			l2s1.SetActive (true);
		}

		if (ggm.stars3_2 >= 2) {

			l2s2.SetActive (true);
		}

		if (ggm.stars3_2 >= 3) {

			l2s3.SetActive (true);
		}

		if (ggm.stars3_3 >= 1) {

			l3s1.SetActive (true);
		}

		if (ggm.stars3_3 >= 2) {

			l3s2.SetActive (true);
		}

		if (ggm.stars3_3 >= 3) {

			l3s3.SetActive (true);
		}

		if (ggm.stars3_4 >= 1) {

			l4s1.SetActive (true);
		}

		if (ggm.stars3_4 >= 2) {

			l4s2.SetActive (true);
		}

		if (ggm.stars3_4 >= 3) {

			l4s3.SetActive (true);
		}

		if (ggm.stars3_5 >= 1) {

			l5s1.SetActive (true);
		}

		if (ggm.stars3_5 >= 2) {

			l5s2.SetActive (true);
		}

		if (ggm.stars3_5 >= 3) {

			l5s3.SetActive (true);
		}

		if (ggm.stars3_6 >= 1) {

			l6s1.SetActive (true);
		}

		if (ggm.stars3_6 >= 2) {

			l6s2.SetActive (true);
		}

		if (ggm.stars3_6 >= 3) {

			l6s3.SetActive (true);
		}

		if (ggm.stars3_7 >= 1) {

			l7s1.SetActive (true);
		}

		if (ggm.stars3_7 >= 2) {

			l7s2.SetActive (true);
		}

		if (ggm.stars3_7 >= 3) {

			l7s3.SetActive (true);
		}

		if (ggm.stars3_8 >= 1) {

			l8s1.SetActive (true);
		}

		if (ggm.stars3_8 >= 2) {

			l8s2.SetActive (true);
		}

		if (ggm.stars3_8 >= 3) {

			l8s3.SetActive (true);
		}
	}

	void Update () {
		if (ggm.worldLevels >= 3.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
			lock2.SetActive (false);
			l2StarBack.SetActive (true);
			if (ggm.worldLevels > 3.2) {
				if (connectors [0].GetComponent<Image> ().fillAmount < 1) {
					connectors [0].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [0].GetComponent<Image> ().fillAmount < 1) {
					connectors [0].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 3.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
			lock3.SetActive (false);
			l3StarBack.SetActive (true);
			if (ggm.worldLevels > 3.3) {
				if (connectors [1].GetComponent<Image> ().fillAmount < 1) {
					connectors [1].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [1].GetComponent<Image> ().fillAmount < 1) {
					connectors [1].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 3.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
			lock4.SetActive (false);
			l4StarBack.SetActive (true);
			if (ggm.worldLevels > 3.4) {
				if (connectors [2].GetComponent<Image> ().fillAmount < 1) {
					connectors [2].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [2].GetComponent<Image> ().fillAmount < 1) {
					connectors [2].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 3.4f)
		{
			level5Button.GetComponent<Button> ().interactable = true;
			lock5.SetActive (false);
			l5StarBack.SetActive (true);
			if (ggm.worldLevels > 3.5) {
				if (connectors [3].GetComponent<Image> ().fillAmount < 1) {
					connectors [3].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [3].GetComponent<Image> ().fillAmount < 1) {
					connectors [3].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 3.5f)
		{
			level6Button.GetComponent<Button> ().interactable = true;
			lock6.SetActive (false);
			l6StarBack.SetActive (true);
			if (ggm.worldLevels > 3.6) {
				if (connectors [4].GetComponent<Image> ().fillAmount < 1) {
					connectors [4].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [4].GetComponent<Image> ().fillAmount < 1) {
					connectors [4].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 3.6f)
		{
			level7Button.GetComponent<Button> ().interactable = true;
			lock7.SetActive (false);
			l7StarBack.SetActive (true);
			if (ggm.worldLevels > 3.7) {
				if (connectors [5].GetComponent<Image> ().fillAmount < 1) {
					connectors [5].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [5].GetComponent<Image> ().fillAmount < 1) {
					connectors [5].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 3.7f)
		{
			level8Button.GetComponent<Button> ().interactable = true;
			lock8.SetActive (false);
			l8StarBack.SetActive (true);
			if (ggm.worldLevels > 3.8) {
				if (connectors [6].GetComponent<Image> ().fillAmount < 1) {
					connectors [6].GetComponent<Image> ().fillAmount = 1f;
				}

			} else {
				if (connectors [6].GetComponent<Image> ().fillAmount < 1) {
					connectors [6].GetComponent<Image> ().fillAmount += 0.015f;
				}
			}
		}
		if (ggm.worldLevels >= 3.8f)
		{
			miniGameButton.GetComponent<Button> ().interactable = true;
			mainLock.SetActive (false);
		}
	}

	public void GoToLevel(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
