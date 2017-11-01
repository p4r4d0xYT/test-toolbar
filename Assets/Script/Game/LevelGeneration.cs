using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
	public GameObject[] pieces;
	public float distanceToPlayer;
	public int chosenPiece;
	public int lastPiece;
	public GameObject thisPiece;
	public GameObject nextPiece;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		chosenPiece = Random.Range (0, 2);
	}
	
	// Update is called once per frame
	void Update () {
		distanceToPlayer = Vector2.Distance (player.transform.position, thisPiece.transform.position);
		if (distanceToPlayer > 8 && distanceToPlayer < 8.5) {
			ReRoll ();
		}
	}
	void ReRoll () {
		chosenPiece = Random.Range (0, 3);
		//if (chosenPiece == lastPiece) {
			//ReRoll ();
		//} else {
			GeneratePiece ();
		//}
	}
	void GeneratePiece () {
		thisPiece = Instantiate (pieces[chosenPiece], new Vector2
		(thisPiece.transform.position.x + 32, thisPiece.transform.position.y), 
		thisPiece.transform.rotation);
		if (thisPiece == pieces[0]) {
			lastPiece = 1;
		} else if (thisPiece == pieces[1]) {
			lastPiece = 2;
		} else if (thisPiece == pieces[2]) {
			lastPiece = 3;
		}
	}
}
