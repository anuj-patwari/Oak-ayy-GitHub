using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class W3LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button, level5Button, level6Button, level7Button, level8Button, miniGameButton;

	GlobalGameManager ggm;

	[SerializeField]
	Text t1, t2, t3, t4, t5, t6, t7, t8;

	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();
		t1.text = ggm.stars3_1.ToString() + "/3";
		t2.text = ggm.stars3_2.ToString() + "/3";
		t3.text = ggm.stars3_3.ToString() + "/3";
		t4.text = ggm.stars3_4.ToString() + "/3";
		t5.text = ggm.stars3_5.ToString() + "/3";
		t6.text = ggm.stars3_6.ToString() + "/3";
		t7.text = ggm.stars3_7.ToString() + "/3";
		t8.text = ggm.stars3_8.ToString() + "/3";
	}

	void Update () {
		if (ggm.worldLevels >= 3.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 3.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 3.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 3.4f)
		{
			level5Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 3.5f)
		{
			level6Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 3.6f)
		{
			level7Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 3.7f)
		{
			level8Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 3.8f)
		{
			miniGameButton.GetComponent<Button> ().interactable = true;
		}
	}

	public void GoToLevel(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
