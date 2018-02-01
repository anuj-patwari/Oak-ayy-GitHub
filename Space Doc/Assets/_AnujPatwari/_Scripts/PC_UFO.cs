using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_UFO : MonoBehaviour {

	public float thrust;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (transform.right * thrust);
	}
	
	// Update is called once per frame
	void Update () {
		
	}




}
