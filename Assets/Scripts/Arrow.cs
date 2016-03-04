﻿using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public Vector2 velocity;
	public float direction;
	public float secondsToDestroy;
	public float damage;
	public float bloodiness;

	private Transform t;


	// Use this for initialization
	void Start () {
		t = GetComponent <Transform> ();
		Destroy (gameObject, secondsToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		t.position += new Vector3 (velocity.x, velocity.y, 0);
	}

	void OnTriggerEnter2D (Collider2D other) {
		Immunity immunity = other.gameObject.GetComponent <Immunity> ();
		Being target = other.gameObject.GetComponent <Being> ();
		if (immunity.canKnockBack == true) {
			Rigidbody2D otherRigid = other.gameObject.GetComponent <Rigidbody2D> ();
			Vector3 angle = transform.eulerAngles;
			angle.z = direction;
			transform.eulerAngles = angle;
			float knockback = damage / target.maxHP;// * knockbackMultiplier;
			Vector2 velocity = new Vector2 (Mathf.Cos (direction * Mathf.Deg2Rad), Mathf.Sin (direction * Mathf.Deg2Rad)) * knockback;
			otherRigid.velocity = velocity;
		}
		if (immunity.canBleed == true) {
			immunity.Bleed ((int) (damage / target.maxHP * bloodiness));
		}
		Debug.Log ("hi");
		Destroy (gameObject);

	}
}
