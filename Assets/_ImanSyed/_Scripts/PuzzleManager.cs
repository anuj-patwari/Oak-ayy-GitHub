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

	[SerializeField]
	GameObject rainEffect, planet, planetCore;

	GameObject highEffect;

	[SerializeField]
	Material healedMaterial, currMaterial;

	private bool rayHit, completed;
	float lerp = 0;


	void Start()
	{
		ggm = GameObject.FindObjectOfType<GlobalGameManager>();
		//ggm.MusicChange (5);
		currMaterial = planet.GetComponent<MeshRenderer> ().material;
		completed = true;
	}

	void Update () {
		if (piecesPut == 4 && !tex.enabled) {
			tex.enabled = true;
			ggm.WorldCompleted (worldNum);			//StartCoroutine (LevelCompleted ());
		}
		if (completed && worldNum == 2) {
			lerp = Mathf.Lerp (lerp, 1, 0.0025f);
			planet.GetComponent<MeshRenderer> ().material.SetFloat ("_Blend", lerp);
			planetCore.GetComponent<MeshRenderer> ().material.SetFloat ("_Blend", lerp);
			planet.GetComponent<MeshRenderer> ().material.SetColor ("_Tint", Color.Lerp(planet.GetComponent<MeshRenderer> ().material.GetColor("_Tint"), Color.blue, 0.002f));
			planetCore.GetComponent<MeshRenderer> ().material.SetColor ("_Tint", Color.Lerp(planet.GetComponent<MeshRenderer> ().material.GetColor("_Tint"), Color.blue, 0.002f));
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
						if (puzzlePiece != null) {
							puzzlePiece.GetComponentInChildren<MeshRenderer> ().enabled = true;
							CancelInvoke ();
						}
						if (puzzlePiece.GetComponent<PuzzlePieceScript> ().pieceNum == hit.collider.gameObject.GetComponent<PuzzleHoleScript> ().holeNum) {
							if (worldNum == 1) {
								puzzlePiece.transform.position = hit.collider.gameObject.transform.position;
							}
							if (worldNum == 2) {
								puzzlePiece.transform.position = hit.collider.gameObject.transform.position;
								Vector3 pos = puzzlePiece.transform.position;
								switch(puzzlePiece.GetComponent<PuzzlePieceScript>().pieceNum){
								case 0:
									pos.x -= 3;
									break;
								case 1:
									pos.y += 3;
									break;
								case 2:
									pos.y -= 3;
									break;
								case 3:
									pos.x += 3;
									break;
								default:
									Debug.Log ("Error");
									break;
								}
								puzzlePiece.transform.position = pos;
							}
							puzzlePiece.transform.SetParent (hit.collider.gameObject.transform);
							puzzlePiece.transform.rotation = Quaternion.Euler (hit.collider.gameObject.GetComponent<PuzzleHoleScript> ().xRot);
							piecesPut++;
							if (worldNum == 2) {
								GameObject re = Instantiate (rainEffect, puzzlePiece.transform);
								re.transform.localPosition = Vector3.zero;
								puzzlePiece.transform.localScale = new Vector3(0.1f, 0.1f, 1);
							}
						} 
					}
				} else {
					if (hit.collider.tag == "Puzzle Piece") {
						rs.enabled = false;
						rayHit = true;
						if (puzzlePiece) {
							CancelInvoke ();
							puzzlePiece.GetComponentInChildren<MeshRenderer> ().enabled = true;
						}
						puzzlePiece = hit.collider.gameObject;
						InvokeRepeating ("BlinkPiece", 0.25f, 0.25f);
					} 
				}
			} else {
				if (highEffect) {
					highEffect = null;
				}
				if (puzzlePiece) {
					CancelInvoke ();
					puzzlePiece.GetComponentInChildren<MeshRenderer> ().enabled = true;
				}
				rs.enabled = true;
			}
		}
	}

	void BlinkPiece(){
		if (puzzlePiece.GetComponentInChildren<MeshRenderer> ().enabled) {
			puzzlePiece.GetComponentInChildren<MeshRenderer> ().enabled = false;
		} else {
			puzzlePiece.GetComponentInChildren<MeshRenderer> ().enabled = true;
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
		ggm.Save ();
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("World1LevelSelect");
	}
}