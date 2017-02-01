using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class EnemyController:MonoBehaviour
	{
		private GameObject target;
		public float range, speed;
		private bool lookingRight = false;
		private float time;
		void Start(){
			target = GameObject.FindWithTag ("Player");
		}

		void Update(){
			time += Time.deltaTime;
			float dist = Vector3.Distance (transform.position, target.transform.position);
			if (dist < range) {
				Flip ();
				if (time < 1.5)
					Move ();
				if (time > 2)
					time = 0;
			} else {
				Move ();
				if (time > 5) {
					time = -5;
					lookingRight = !lookingRight;
					transform.Rotate (new Vector3 (0, 180, 0));
				}
			}
		}

		private void Flip(){
			if(target.transform.position.x < transform.position.x && lookingRight){
				transform.Rotate (new Vector3 (0, 180, 0));
				lookingRight = false;
			}
			if (target.transform.position.x > transform.position.x && !lookingRight) {
				transform.Rotate (new Vector3 (0, 180, 0));
				lookingRight = true;
			}
		}

		private void Move(){
			GetComponent<Rigidbody2D> ().AddForce (-transform.right.normalized * speed);
		}

	}
}

