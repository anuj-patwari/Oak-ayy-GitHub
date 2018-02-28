using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour {


	public int worldsComplete = 0;
	public int world1levels = 1;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WorldCompleted()
	{
		worldsComplete++;
	}

	public void World1Level()
	{
		world1levels++;
	}
}
