using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour {


	short piecesPut;

	GameObject puzzlePiece;
	public bool world1Complete = false;

	[SerializeField]
	RotationScript rs;

	[SerializeField]
	Text tex;

	private bool rayHit;

	void Update () {
		if (piecesPut == 4 && !tex.enabled) {
			tex.enabled = true;
			world1Complete = true;
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
}
