using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum startDirection{
	up, down, left, right	
}

public class PC_UFO : MonoBehaviour {

	public float thrust;
	bool shiftCamera;

	public startDirection sD;

	public bool isStarted, increaseVelocity;

	[SerializeField]
	GameObject trailObject, deathEffect;

	SceneManagerScript sms;
	GlobalGameManager ggm;

	float colRadius;

	[SerializeField]
	GameObject startEffect;

	GameObject effect;

	void Start(){
		ggm = FindObjectOfType<GlobalGameManager> ();
		sms = FindObjectOfType<SceneManagerScript> ();
		InvokeRepeating ("ShootTrailer", 0, 0.5f);
		colRadius = GetComponent<CircleCollider2D> ().radius;
	}

	void Update () {
		if (ggm.canStart) {
			if (!isStarted) {
				
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
				Debug.DrawRay (ray.origin, ray.direction * 10000, Color.green);
				if (hit.collider != null) {
					if (hit.collider.gameObject == gameObject) {
						isStarted = true;	
						FindObjectOfType<CameraScroll> ().ReturnCamera ();
						sms.DisableScroll ();
						if (sD == startDirection.down) {
							GetComponent<Rigidbody2D> ().AddForce (Vector2.down * thrust);
						} else if (sD == startDirection.up) {
							GetComponent<Rigidbody2D> ().AddForce (Vector2.up * thrust);
						} else if (sD == startDirection.left) {
							GetComponent<Rigidbody2D> ().AddForce (Vector2.left * thrust);
						} else if (sD == startDirection.right) {
							GetComponent<Rigidbody2D> ().AddForce (Vector2.right * thrust);
						}
					}
				}
				if (effect == null) {
					GetComponent<CircleCollider2D>().radius = 2f;
					effect = Instantiate (startEffect, transform.position, Quaternion.identity);
				}
			} else {

				if (effect != null) {
					GetComponent<CircleCollider2D>().radius = colRadius;
					Destroy (effect);
				}

				Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes (Camera.main);
				bool visible = GeometryUtility.TestPlanesAABB (frustumPlanes, GetComponent<Renderer> ().bounds);
				if (!visible) {
					Invoke ("Rest", 1);
				}

				if (increaseVelocity && GetComponent<Rigidbody2D> ().velocity.magnitude < 2f) {
					GetComponent<Rigidbody2D> ().velocity *= 2;
				}
			}
		} 
	}
	void ShootTrailer(){
		GameObject trailBoi = Instantiate (trailObject, transform.position, transform.rotation);
		trailBoi.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity * 20;
		if(gameObject.activeSelf){
			StartCoroutine(DestroyTrailBoi (0.5f, trailBoi));
		}
	}

	public void Rest(){
		sms.RestartInstant ();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Meteor") {
			Destroy (col.gameObject);
			Destroy (gameObject);
		} else if (col.gameObject.tag == "Planet") {
			Destroy (gameObject);
		} else if (col.gameObject.tag == "Rubber") {
			ggm.PlaySoundEffect (1);
		} 
	}

	void OnDestroy(){
		GameObject de = Instantiate (deathEffect, transform.position, Quaternion.identity);
		de.SetActive (true);
		ggm.PlaySoundEffect (1);
		sms.StartCoroutine(sms.RestartAfter (2.5f));
	}


	IEnumerator DestroyTrailBoi(float delay, GameObject ob){
		yield return new WaitForSeconds (delay);
		Destroy (ob);
	}
}
