using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class W2LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button,level5Button, level6Button, miniGameButton;

	GlobalGameManager ggm;

	[SerializeField]
	Text t1, t2, t3, t4, t5, t6;

	[SerializeField]
	GameObject lock2, lock3, lock4, lock5, lock6, mainLock;

	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();
		t1.text = ggm.stars2_1.ToString() + "/3";
		t2.text = ggm.stars2_2.ToString() + "/3";
		t3.text = ggm.stars2_3.ToString() + "/3";
		t4.text = ggm.stars2_4.ToString() + "/3";
		t5.text = ggm.stars2_5.ToString() + "/3";
		t6.text = ggm.stars2_6.ToString() + "/3";
	}

	void Update () {
		if (ggm.worldLevels >= 2.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
			lock2.SetActive (false);
		}
		if (ggm.worldLevels >= 2.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
			lock3.SetActive (false);
		}
		if (ggm.worldLevels >= 2.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
			lock4.SetActive (false);
		}
		if (ggm.worldLevels >= 2.4f)
		{
			level5Button.GetComponent<Button> ().interactable = true;
			lock5.SetActive (false);
		}
		if (ggm.worldLevels >= 2.5f)
		{
			level6Button.GetComponent<Button> ().interactable = true;
			lock6.SetActive (false);
		}
		if (ggm.worldLevels >= 2.6f)
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
