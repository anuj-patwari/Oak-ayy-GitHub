using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour {

	[SerializeField]
	GameObject screenTransition;

	// Use this for initialization
	void Start () 
	{
		
		StartCoroutine (Effect());
	}
	
	// Update is called once per frame
	IEnumerator Effect ()
	{
		yield return new WaitForSeconds (34);
		screenTransition.GetComponent<Animator> ().SetInteger ("e", 1);
		StartCoroutine (BackToMainMenu (1));
	}

	IEnumerator BackToMainMenu(float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene ("MainMenu");
	}
}
