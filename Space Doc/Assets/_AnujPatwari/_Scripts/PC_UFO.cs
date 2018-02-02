using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC_UFO : MonoBehaviour {

	public float thrust;
	bool isStarted;

	// Use this for initialization
	void Start () 
	{
	

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){
		if (!isStarted) {

			GetComponent<Rigidbody2D> ().AddForce (transform.right * thrust);
			isStarted = true;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.gameObject.tag == "Meteor") {

			Destroy (col.gameObject);
			StartCoroutine (Restart(1));
		}

	}

	IEnumerator Restart (float restartAfter)
	{

		yield return new WaitForSeconds (restartAfter);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);

	}
}
