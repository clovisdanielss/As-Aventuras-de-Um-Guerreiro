using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour {
	private int hp;
	public int maxHp;
	private int ammo;
	public int maxAmmo;

	// Use this for initialization
	void Start () {
		hp = maxHp;
		ammo = maxAmmo;
	}

	// Update is called once per frame
	void Update () {
		if (hp <= 0)
			Destroy (gameObject);
	}

	public int GetHP(){
		return hp;
	}

	public int GetAmmo(){
		return ammo;
	}

	public virtual int DecremmentAmmo(){
		ammo -= 1;
		return ammo;
	}

	public virtual int TakeDamage(int dmg){
		hp -= dmg;
		return hp;
	}
}