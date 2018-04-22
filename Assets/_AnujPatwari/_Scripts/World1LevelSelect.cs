using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class World1LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button, miniGameButton;

	GlobalGameManager ggm;

	//Stars
	[SerializeField]
	GameObject l1s1, l1s2, l1s3, l2s1, l2s2, l2s3, l3s1, l3s2, l3s3, l4s1, l4s2, l4s3;

	//Star Back
	[SerializeField]
	GameObject l2StarBack, l3StarBack, l4StarBack;


	[SerializeField]
	GameObject lock2, lock3, lock4, mainLock;

	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();

		if (ggm.stars1_1 >= 1) {

			l1s1.SetActive (true);
		}

		if (ggm.stars1_1 >= 2) {

			l1s2.SetActive (true);
		}

		if (ggm.stars1_1 >= 3) {

			l1s3.SetActive (true);
		}
		if (ggm.stars1_2 >= 1) {

			l2s1.SetActive (true);
		}

		if (ggm.stars1_2 >= 2) {

			l2s2.SetActive (true);
		}

		if (ggm.stars1_2 >= 3) {

			l2s3.SetActive (true);
		}

		if (ggm.stars1_3 >= 1) {

			l3s1.SetActive (true);
		}

		if (ggm.stars1_3 >= 2) {

			l3s2.SetActive (true);
		}

		if (ggm.stars1_3 >= 3) {

			l3s3.SetActive (true);
		}

		if (ggm.stars1_4 >= 1) {

			l4s1.SetActive (true);
		}

		if (ggm.stars1_4 >= 2) {

			l4s2.SetActive (true);
		}

		if (ggm.stars1_4 >= 3) {

			l4s3.SetActive (true);
		}

	}

	void Update () {
		if (ggm.worldLevels >= 1.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
			lock2.SetActive (false);
			l2StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 1.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
			lock3.SetActive (false);
			l3StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 1.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
			lock4.SetActive (false);
			l4StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 1.4f)
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
