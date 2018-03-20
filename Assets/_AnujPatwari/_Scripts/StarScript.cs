using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

	GlobalGameManager ggm;

	void Start()
	{
		ggm = FindObjectOfType<GlobalGameManager> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			ggm.currStars++;
			Destroy (gameObject);
		}
	}
}
