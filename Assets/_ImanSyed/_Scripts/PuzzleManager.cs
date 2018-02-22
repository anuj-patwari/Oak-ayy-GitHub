using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {


	GameObject puzzlePiece;

	[SerializeField]
	RotationScript rs;

	[SerializeField]
	GameObject planet;

	private bool rayHit;

	void Update () {
		if (rayHit) {
			if (Input.GetMouseButtonUp (0)) {
				rayHit = false;
			}
		}
		if (Input.GetMouseButton (0) && !rayHit) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast (ray, out hit, 1000);
			Debug.DrawRay (ray.origin, ray.direction * 10000, Color.green);
			if (hit.collider != null) {
				if (!rs.enabled) {
					rs.enabled = true;
					if (hit.collider.tag == "Planet") {
						puzzlePiece.transform.position = hit.collider.gameObject.transform.position;
						puzzlePiece.transform.SetParent (hit.collider.gameObject.transform);
						puzzlePiece.transform.rotation.eulerAngles = hit.collider.gameObject.GetComponent<PuzzleHoleScript> ().xRot;
						Debug.Log (gameObject);
					}
				} else {
					if (hit.collider.tag == "Puzzle Piece") {
						rs.enabled = false;
						rayHit = true;
						puzzlePiece = hit.collider.gameObject;
					} 
				}
			}
		}
	}
}
