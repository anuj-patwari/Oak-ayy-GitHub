using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlanetScript : MonoBehaviour {

	[SerializeField]
	Rigidbody2D playerCharacter;

	bool pcIsIn;

	[SerializeField]
	float force;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0) && pcIsIn) 
		{
			

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			//Debug.DrawRay(ray.origin, ray.direction * 1000000, Color.green);
			if (hit.collider != null) {
				if (hit.collider.tag == "Finish") {
					Vector2 forceDirection =  transform.position - playerCharacter.gameObject.transform.position;
					playerCharacter.AddForce (forceDirection.normalized * force * Time.deltaTime);
				}
			}

		}

	}
		

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.tag == "Player") {

			pcIsIn = true;
		}

	}

	void OnTriggerExit2D (Collider2D col)
	{

		if (col.tag == "Player") {

			pcIsIn = false;
		}

	}

}
