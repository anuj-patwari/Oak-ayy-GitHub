using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class W4LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button, level5Button, level6Button, level7Button, level8Button, level9Button, level10Button, miniGameButton;

	GlobalGameManager ggm;

	//Stars
	[SerializeField]
	GameObject l1s1, l1s2, l1s3, l2s1, l2s2, l2s3, l3s1, l3s2, l3s3, l4s1, l4s2, l4s3, l5s1, l5s2, l5s3, l6s1, l6s2, l6s3, l7s1, l7s2, l7s3, l8s1, l8s2, l8s3, l9s1, l9s2, l9s3, l10s1, l10s2, l10s3;

	//Star Back
	[SerializeField]
	GameObject l2StarBack, l3StarBack, l4StarBack, l5StarBack, l6StarBack, l7StarBack, l8StarBack, l9StarBack, l10StarBack;


	[SerializeField]
	GameObject lock2, lock3, lock4, lock5, lock6, lock7, lock8, lock9, lock10, mainLock;

	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();


		if (ggm.stars4_1 >= 1) {

			l1s1.SetActive (true);
		}

		if (ggm.stars4_1 >= 2) {

			l1s2.SetActive (true);
		}

		if (ggm.stars4_1 >= 3) {

			l1s3.SetActive (true);
		}

		if (ggm.stars4_2 >= 1) {

			l2s1.SetActive (true);
		}

		if (ggm.stars4_2 >= 2) {

			l2s2.SetActive (true);
		}

		if (ggm.stars4_2 >= 3) {

			l2s3.SetActive (true);
		}

		if (ggm.stars4_3 >= 1) {

			l3s1.SetActive (true);
		}

		if (ggm.stars4_3 >= 2) {

			l3s2.SetActive (true);
		}

		if (ggm.stars4_3 >= 3) {

			l3s3.SetActive (true);
		}

		if (ggm.stars4_4 >= 1) {

			l4s1.SetActive (true);
		}

		if (ggm.stars4_4 >= 2) {

			l4s2.SetActive (true);
		}

		if (ggm.stars4_4 >= 3) {

			l4s3.SetActive (true);
		}

		if (ggm.stars4_5 >= 1) {

			l5s1.SetActive (true);
		}

		if (ggm.stars4_5 >= 2) {

			l5s2.SetActive (true);
		}

		if (ggm.stars4_5 >= 3) {

			l5s3.SetActive (true);
		}

		if (ggm.stars4_6 >= 1) {

			l6s1.SetActive (true);
		}

		if (ggm.stars4_6 >= 2) {

			l6s2.SetActive (true);
		}

		if (ggm.stars4_6 >= 3) {

			l6s3.SetActive (true);
		}

		if (ggm.stars4_7 >= 1) {

			l7s1.SetActive (true);
		}

		if (ggm.stars4_7 >= 2) {

			l7s2.SetActive (true);
		}

		if (ggm.stars4_7 >= 3) {

			l7s3.SetActive (true);
		}

		if (ggm.stars4_8 >= 1) {

			l8s1.SetActive (true);
		}

		if (ggm.stars4_8 >= 2) {

			l8s2.SetActive (true);
		}

		if (ggm.stars4_8 >= 3) {

			l8s3.SetActive (true);
		}

		if (ggm.stars4_9 >= 1) {

			l9s1.SetActive (true);
		}

		if (ggm.stars4_9 >= 2) {

			l9s2.SetActive (true);
		}

		if (ggm.stars4_9 >= 3) {

			l9s3.SetActive (true);
		}

		if (ggm.stars4_10 >= 1) {

			l10s1.SetActive (true);
		}

		if (ggm.stars4_10 >= 2) {

			l10s2.SetActive (true);
		}

		if (ggm.stars4_10 >= 3) {

			l10s3.SetActive (true);
		}
	}

	void Update () {
		if (ggm.worldLevels >= 4.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
			lock2.SetActive (false);
			l2StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
			lock3.SetActive (false);
			l3StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
			lock4.SetActive (false);
			l4StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.4f)
		{
			level5Button.GetComponent<Button> ().interactable = true;
			lock5.SetActive (false);
			l5StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.5f)
		{
			level6Button.GetComponent<Button> ().interactable = true;
			lock6.SetActive (false);
			l6StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.6f)
		{
			level7Button.GetComponent<Button> ().interactable = true;
			lock7.SetActive (false);
			l7StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.7f)
		{
			level8Button.GetComponent<Button> ().interactable = true;
			lock8.SetActive (false);
			l8StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.8f)
		{
			level9Button.GetComponent<Button> ().interactable = true;
			lock9.SetActive (false);
			l9StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.9f)
		{
			level10Button.GetComponent<Button> ().interactable = true;
			lock10.SetActive (false);
			l10StarBack.SetActive (true);
		}
		if (ggm.worldLevels >= 4.91f)
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
