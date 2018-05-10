using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldSelectManager : MonoBehaviour {

	//[SerializeField]
	//Sprite w1Complete, w1Incomplete, w2Complete, w2Incomplete,  w3Complete, w3Incomplete, w4Complete, w4Incomplete;

	[SerializeField]
	GameObject w2Locked, w3Locked, w4Locked, screenTransition;

	[SerializeField]
	Image world1State, world2State, world3State, world4State;

	[SerializeField]
	Text t1, t2, t3, t4;

	int w1Stars, w2Stars, w3Stars, w4Stars;

	[SerializeField]
	Sprite toggleSoundSprite, toggleOrigSoundSprite;

	[SerializeField]
	Image soundToggleButton;

	[SerializeField]
	float soundToggleDelay = 0.2f;

	GlobalGameManager ggm;


	void Start () {
		ggm = GameObject.FindObjectOfType<GlobalGameManager> ();
		screenTransition.SetActive (true);
		w1Stars = ggm.stars1_1 + ggm.stars1_2 + ggm.stars1_3 + ggm.stars1_4;
		w2Stars = ggm.stars2_1 + ggm.stars2_2 + ggm.stars2_3 + ggm.stars2_4 + ggm.stars2_5 + ggm.stars2_6;
		w3Stars = ggm.stars3_1 + ggm.stars3_2 + ggm.stars3_3 + ggm.stars3_4 + ggm.stars3_5 + ggm.stars3_6 + ggm.stars3_7 + ggm.stars3_8;
		w4Stars = ggm.stars4_1 + ggm.stars4_2 + ggm.stars4_3 + ggm.stars4_4 + ggm.stars4_5 + ggm.stars4_6 + ggm.stars4_7 + ggm.stars4_8 + ggm.stars4_9 + ggm.stars4_10;

		t1.text = w1Stars.ToString() + "/12";
		t2.text = w2Stars.ToString() + "/18";
		t3.text = w3Stars.ToString() + "/24";
		t4.text = w4Stars.ToString() + "/30";
	}
	
	void Update () {

		//Changing the states of the Selection Panels to Sick or Fixed
		/*
		if (ggm.worldsComplete > 0) {
			world1State.sprite = w1Complete;
		} else {
			world1State.sprite = w1Incomplete;
		}
		if (ggm.worldsComplete > 1) {
			world2State.sprite = w2Complete;
		} else {
			world2State.sprite = w2Incomplete;
		}
		if (ggm.worldsComplete > 2) {
			world3State.sprite = w3Complete;
		} else {
			world3State.sprite = w3Incomplete;
		}
		if (ggm.worldsComplete > 3) { 
			world4State.sprite = w4Complete; 
		} else {
			world4State.sprite = w4Incomplete;
		}*/

		//Changing the states of the Selection Planets to Locked or Unlocked

		if (ggm.worldsComplete == 0) {
			w2Locked.SetActive (true);
			w3Locked.SetActive (true);
			w4Locked.SetActive (true);
		} else if (ggm.worldsComplete == 1) 
		{
			w2Locked.SetActive (false);
			w3Locked.SetActive (true);
			w4Locked.SetActive (true);
		} else if (ggm.worldsComplete == 2) 
		{
			w2Locked.SetActive (false);
			w3Locked.SetActive (false);
			w4Locked.SetActive (true);
		}
		else if (ggm.worldsComplete == 3) 
		{
			w2Locked.SetActive (false);
			w3Locked.SetActive (false);
			w4Locked.SetActive (false);
		}
	}

	public void MainMenu()
	{
		StartCoroutine(GoToScene ("MainMenu"));
	}

	public void GoToWorld(string worldName)
	{
		StartCoroutine(GoToScene (worldName));
	}
		
	IEnumerator GoToScene(string world){
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (world);
	}



	public void toggleSoundSpriteFn()
	{
		StartCoroutine(toggleSound());
	}

	IEnumerator toggleSound()
	{
		yield return new WaitForSeconds (soundToggleDelay);
		if (soundToggleButton.sprite == toggleOrigSoundSprite) {
			//when sound is on
			soundToggleButton.sprite = toggleSoundSprite;
			ggm.as1.mute = true;
			ggm.as2.mute = true;
			ggm.muted = true;
			ggm.Save ();

		} else {
			//when sound is off
			soundToggleButton.sprite = toggleOrigSoundSprite;
			ggm.as1.mute = false;
			ggm.as2.mute = false;
			ggm.muted = false;
			ggm.Save ();
		}
	}



	public void loadCredits()
	{
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		StartCoroutine (loadCreditsFn (1));
	}

	IEnumerator loadCreditsFn(float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene ("Credits");
	}
}
