using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour {


	public short worldsComplete = 0;
	public float world1levels = 1;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WorldCompleted(short worldNum)
	{
		if (worldNum > worldsComplete) {
			worldsComplete = worldNum;
		}
	}

	public void World1Level(float levelNumber)
	{
		if (levelNumber > world1levels) {
			world1levels = levelNumber;
		}
	}
}
