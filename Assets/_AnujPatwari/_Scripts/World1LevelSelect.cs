using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class World1LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button, miniGameButton;

	GlobalGameManager ggm;

	// Use this for initialization
	void Start () {

		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (ggm.worldLevels >= 1.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 1.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 1.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels == 1.4f)
		{
			miniGameButton.GetComponent<Button> ().interactable = true;
		}
		
	}

	public void GoToLevel(int sceneIndex)
	{

		SceneManager.LoadScene (sceneIndex);

	}
}
