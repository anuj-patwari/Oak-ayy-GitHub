using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	[SerializeField]
	GameObject meteor;

    [SerializeField]
    float repeatValue = 4;



	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnMeteor", 0, repeatValue);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnMeteor ()
	{
		GameObject m = Instantiate (meteor, transform.position, Quaternion.identity);
		m.GetComponent<Rigidbody2D> ().AddForce (transform.up * -500);
		m.GetComponent<Rigidbody2D> ().AddForce (transform.right * -300);
		StartCoroutine (DestroyMeteor (5, m));

	}

	IEnumerator DestroyMeteor (float delay, GameObject met)
	{

		yield return new WaitForSeconds (delay);
		Destroy (met);

	}
}
