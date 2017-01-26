using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour {

	private Rigidbody2D myBody;
	private Vector3 direction;
	private Vector3 initialPos;
	public bool fliped = false;
	public float speed;
	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		myBody = GetComponent<Rigidbody2D> ();
		direction = transform.up;
		Rotate ();
	}
	
	// Update is called once per frame
	void Update () {
		myBody.AddForce (direction * speed);
		CheckDist ();
	}

	public void FlipDirection(){
		if (fliped == true)
			fliped = false;
		else
			fliped = true;
	}

	private void Rotate(){
		if (fliped) {
			transform.Rotate (new Vector3 (0, 0, 180));
			direction *= -1;
		}
	}

	public bool IsFliped(){
		return fliped;
	}

	private void CheckDist(){
		float dist = Vector3.Distance (transform.position, initialPos);
		if (dist < 0)
			dist *= -1;
		if (dist > 25)
			Destroy (gameObject);
	}

}
