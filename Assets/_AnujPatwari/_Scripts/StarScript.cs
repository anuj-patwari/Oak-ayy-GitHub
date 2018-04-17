using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

	GlobalGameManager ggm;

	public GameObject collectedEffect;

	void Start()
	{
		ggm = FindObjectOfType<GlobalGameManager> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			ggm.currStars++;
			ggm.PlaySoundEffect (3);
			GameObject effect = Instantiate (collectedEffect, transform.position, transform.rotation);
			effect.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			Destroy (gameObject);
		}
	}
}
