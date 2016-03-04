using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public Vector2 velocity;

	private Transform t;

	// Use this for initialization
	void Start () {
		t = GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		t.position += new Vector3 (velocity.x, velocity.y, 0);
	}
}
