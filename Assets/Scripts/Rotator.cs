using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private Transform t;

	// Use this for initialization
	void Start () {
		t = GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mouseLocation = ((Vector2) Camera.main.ScreenToWorldPoint (Input.mousePosition));
		mouseLocation = mouseLocation - ((Vector2) t.position);
		float aimDirection = Mathf.Atan2 (mouseLocation.y, mouseLocation.x) * Mathf.Rad2Deg;
		Vector3 angle = t.eulerAngles;
		angle.z = aimDirection;
		t.eulerAngles = angle;
	}
}
