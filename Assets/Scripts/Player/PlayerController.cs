using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Animator myAnimation;
	private Rigidbody2D myRigidbody;
	private bool lookingRight;
	private bool jump;
	public GameObject[] weapons;
	public float speed;
	private Vector3 oldPos;
	// Use this for initialization
	void Start () {
		oldPos = transform.position;
		jump = true;
		lookingRight = true;
		myAnimation = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = new Vector3 (transform.position.x,Camera.main.transform.position.y , -10);
		Moviment ();
		Attack ();
		MeleeAttack ();
		Jump ();
		CheckFloating ();
	}

	private void CheckFloating(){
		if (oldPos.y != transform.position.y) {
			myRigidbody.gravityScale = 3;
		}
		oldPos = transform.position;			
	}

	private void Moviment(){
		if (!Input.GetButton ("Fire1")) {
			float move = Input.GetAxis ("Horizontal");
			if (move < 0 && lookingRight) {
				transform.Rotate (new Vector3 (0, 180, 0));
				lookingRight = false;
			} else if (move > 0 && !lookingRight) {
				transform.Rotate (new Vector3 (0, 180, 0));
				lookingRight = true;
			}
			if (move >= .75 || move <= -.75)
				myAnimation.SetTrigger ("Walk");
			if (lookingRight)
				myRigidbody.AddForce (transform.right * speed * move);
			else
				myRigidbody.AddForce (-transform.right * speed * move);
		}
	}


	private void Attack(){
		if (Input.GetButtonDown ("Fire1")) {
			myAnimation.SetTrigger ("Attack");
			GameObject attack = weapons [0]; // Daggers Id.

			attack.transform.position = transform.position;

			GameObject newa = Instantiate (attack) as GameObject;

			if (lookingRight && newa.GetComponent<Dagger> ().IsFliped () == true) {
				newa.GetComponent<Dagger> ().fliped = false;
			}
			else if (!lookingRight && newa.GetComponent<Dagger> ().IsFliped () == false) {
				newa.GetComponent<Dagger> ().fliped = true;
			}

		}
	}

	private void MeleeAttack(){
		if (Input.GetButtonDown ("Fire2")) {
			myAnimation.SetTrigger ("MeleeAttack");
		}
	}

	private void Jump(){
		if (Input.GetButtonDown ("Jump") && jump == false) {
			myRigidbody.gravityScale = 3;
			jump = true;
			myAnimation.SetBool ("Jump", jump);
			myRigidbody.AddForce (transform.up * 150000);
		} 

	}

	void OnCollisionEnter2D(Collision2D other){
		myRigidbody.gravityScale = 1;
		if( jump == true && other.gameObject.tag == "Floor"){
			
			jump = false;
			myAnimation.SetBool ("Jump", jump);
		}
	}

	public void SetJump(bool b){
		jump = b;
	}
		
}
