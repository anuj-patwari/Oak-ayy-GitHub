using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class W2LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button, miniGameButton;

	GlobalGameManager ggm;

	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();
	}

	void Update () {
		if (ggm.worldLevels >= 2.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 2.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 2.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels == 2.4f)
		{
			miniGameButton.GetComponent<Button> ().interactable = true;
		}
	}

	public void GoToLevel(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
