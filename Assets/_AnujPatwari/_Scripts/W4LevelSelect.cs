using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class W4LevelSelect : MonoBehaviour {

	[SerializeField]
	GameObject level2Button, level3Button, level4Button, level5Button, level6Button, level7Button, level8Button, level9Button, level10Button, miniGameButton;

	GlobalGameManager ggm;

	[SerializeField]
	Text t1, t2, t3, t4, t5, t6, t7, t8, t9, t10;

	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();
		t1.text = ggm.stars4_1.ToString() + "/3";
		t2.text = ggm.stars4_2.ToString() + "/3";
		t3.text = ggm.stars4_3.ToString() + "/3";
		t4.text = ggm.stars4_4.ToString() + "/3";
		t5.text = ggm.stars4_5.ToString() + "/3";
		t6.text = ggm.stars4_6.ToString() + "/3";
		t7.text = ggm.stars4_7.ToString() + "/3";
		t8.text = ggm.stars4_8.ToString() + "/3";
		t9.text = ggm.stars4_9.ToString() + "/3";
		t10.text = ggm.stars4_10.ToString() + "/3";
	}

	void Update () {
		if (ggm.worldLevels >= 4.1f)
		{
			level2Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.2f)
		{
			level3Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.3f)
		{
			level4Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.4f)
		{
			level5Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.5f)
		{
			level6Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.6f)
		{
			level7Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.7f)
		{
			level8Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.8f)
		{
			level9Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.9f)
		{
			level10Button.GetComponent<Button> ().interactable = true;
		}
		if (ggm.worldLevels >= 4.10f)
		{
			miniGameButton.GetComponent<Button> ().interactable = true;
		}
	}

	public void GoToLevel(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
