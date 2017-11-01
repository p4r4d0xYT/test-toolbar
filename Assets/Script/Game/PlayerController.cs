using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	Camera cam;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		rb = GetComponent<Rigidbody> ();
	}
	
	void Awake () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal") * 4f;
		float moveVertical = Input.GetAxis ("Vertical") * speed;

		if (!GameManager.instance.isPaused) {
			transform.Translate (0, 0, moveVertical);
			transform.Rotate (0, moveHorizontal, 0);
		}
	}

	void Update () {
		cam.transform.position = new Vector3 (transform.position.x, transform.position.y + 8f, transform.position.z);
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Grass") {
			speed = 0.05f;
		} else if (col.gameObject.tag == "Road") {
			speed = 0.2f;
		} else if (col.gameObject.tag == "Killer") {
			Destroy (gameObject, 0.2f);
		}
	}
}