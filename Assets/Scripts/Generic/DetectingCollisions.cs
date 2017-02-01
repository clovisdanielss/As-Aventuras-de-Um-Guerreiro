using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll){
		Debug.Log (gameObject.name + "  Collision Detected.");
	}
	// Ambos vão detectar o gatilho(Colisor e colidido).
	void OnTriggerEnter2D(Collider2D coll){
		if (gameObject.tag == "PlayerWeapon") {
			if (coll.tag == "Enemy") {
				Debug.Log("Enemy's HP:" + coll.GetComponent<Status> ().TakeDamage (GetComponent<WeaponStatus> ().dmg));				Vector3 dir = coll.transform.position - transform.position;
				coll.GetComponent<Rigidbody2D> ().AddForce (15000*new Vector2(dir.x, dir.y));
			}
		}
		if (gameObject.tag == "EnemyWeapon") {
			
			if (coll.tag == "Player") {
				Debug.Log("Player's HP:" + coll.GetComponent<Status> ().TakeDamage (GetComponent<WeaponStatus> ().dmg));
				Vector3 dir = coll.transform.position - transform.position;
				coll.GetComponent<Rigidbody2D> ().AddForce (25000*new Vector2(dir.x,dir.y));
				coll.GetComponent<Rigidbody2D> ().gravityScale = 3;
				coll.GetComponent<PlayerController> ().SetJump (true);

			}
		}
	}
}