using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorchPuzzle : MonoBehaviour {
	public short currentIndex = 0;

	public void Mistake(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
