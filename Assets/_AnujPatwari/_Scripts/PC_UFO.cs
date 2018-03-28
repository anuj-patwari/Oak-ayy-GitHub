using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum startDirection{
	up, down, left, right	
}

public class PC_UFO : MonoBehaviour {

	public float thrust;
	bool isStarted, shiftCamera;

	public startDirection sD;

	public bool increaseVelocity;

	[SerializeField]
	GameObject trailObject;

	SceneManagerScript sms;
	GlobalGameManager ggm;


	void Start(){
		ggm = FindObjectOfType<GlobalGameManager> ();
		sms = FindObjectOfType<SceneManagerScript> ();
		InvokeRepeating ("ShootTrailer", 0, 0.5f);
	}

	void Update () {
		if (ggm.animationIsPlaying == 2) {
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
			} else {
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

	void Rest(){
		sms.RestartInstant ();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Meteor") {
			Destroy (col.gameObject);
			StartCoroutine(sms.RestartAfter (1));
		}
		if (col.gameObject.tag == "Planet") {
			Destroy (gameObject);
			sms.StartCoroutine(sms.RestartAfter (1));
		}
		if (col.gameObject.tag == "Rubber") {
			
		}
		if (col.gameObject.tag == "Bubble") {
			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 2.5f) {
				Destroy (col.gameObject);
			} else {
				Rest ();
			}
		}
	}

	IEnumerator DestroyTrailBoi(float delay, GameObject ob){
		yield return new WaitForSeconds (delay);
		Destroy (ob);
	}
}
