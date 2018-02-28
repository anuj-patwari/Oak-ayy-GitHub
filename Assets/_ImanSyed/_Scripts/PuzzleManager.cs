using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour {

	GlobalGameManager ggm;
	short piecesPut;

	GameObject puzzlePiece;

	[SerializeField]
	RotationScript rs;

	[SerializeField]
	Text tex;

	[SerializeField]
	short worldNum = 1;

	private bool rayHit;

	void Start()
	{
		ggm = GameObject.FindObjectOfType<GlobalGameManager>();
		print (ggm.world1levels);
	}

	void Update () {
		if (piecesPut == 4 && !tex.enabled) {
			tex.enabled = true;
			ggm.WorldCompleted (worldNum);
			StartCoroutine (LevelCompleted ());
		}
		if (rayHit) {
			if (Input.GetMouseButtonUp (0)) {
				rayHit = false;
			}
		} 
		if (Input.GetMouseButton (0) && !rayHit) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast (ray, out hit, 1000);
			Debug.DrawRay (ray.origin, ray.direction * 1000, Color.green);
			if (hit.collider != null) {
				if (!rs.enabled) {
					rs.enabled = true;
					if (hit.collider.tag == "Planet") {
						if (puzzlePiece.GetComponent<PuzzlePieceScript> ().pieceNum == hit.collider.gameObject.GetComponent<PuzzleHoleScript> ().holeNum) {
							puzzlePiece.transform.position = hit.collider.gameObject.transform.position;
							puzzlePiece.transform.SetParent (hit.collider.gameObject.transform);
							puzzlePiece.transform.rotation = Quaternion.Euler (hit.collider.gameObject.GetComponent<PuzzleHoleScript> ().xRot);
							piecesPut++;
						}
					}
				} else {
					if (hit.collider.tag == "Puzzle Piece") {
						rs.enabled = false;
						rayHit = true;
						puzzlePiece = hit.collider.gameObject;
					} 
				}
			} else {
				rs.enabled = true;
			}
		}
	}
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator LevelCompleted ()
	{
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("World1LevelSelect");
	}
}
