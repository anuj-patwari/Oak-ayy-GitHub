using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	[SerializeField]
	GameObject meteor;

    [SerializeField]
    float repeatValue = 4;

	[SerializeField]
	float destroyTiming = 5;

	float rot;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnMeteor", 0, repeatValue);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnMeteor ()
	{
		GameObject m = Instantiate (meteor, transform.position, Quaternion.Euler(new Vector3(180 - transform.eulerAngles.z, 90, 0)));
		m.GetComponent<Rigidbody2D> ().AddForce (transform.right * 500);
		StartCoroutine (DestroyMeteor (destroyTiming, m));

	}

	IEnumerator DestroyMeteor (float delay, GameObject met)
	{

		yield return new WaitForSeconds (delay);
		Destroy (met);

	}
}
