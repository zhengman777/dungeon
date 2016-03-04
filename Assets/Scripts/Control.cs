using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	private Transform t;
	private Being being;
	private Rigidbody2D rb2d;
	private float strength;
	private ArrowLauncher arrowLauncher;


	// Use this for initialization
	void Start () {
		t = GetComponent <Transform> ();
		being = GetComponent <Being> ();
		rb2d = GetComponent <Rigidbody2D> ();
		strength = being.strength;
		arrowLauncher = GetComponent <ArrowLauncher> ();
	}

	void Update () {
		if (Input.GetMouseButtonUp (0) == true) {
			arrowLauncher.Launch (t.position, AimDirection(), strength);
		}
	}

	void FixedUpdate () {
		Vector2 bVec = new Vector2 (Input.GetAxis ("Horizontal"),Input.GetAxis ("Vertical"));
		bVec.Normalize ();
		Vector2 vel = rb2d.velocity;
		vel = bVec * being.movementSpeed;
		rb2d.velocity = vel;
	}

	public float AimDirection () {
		Vector2 mouseLocation = ((Vector2) Camera.main.ScreenToWorldPoint (Input.mousePosition));
		mouseLocation = mouseLocation - ((Vector2) t.position);
		return Mathf.Atan2 (mouseLocation.y, mouseLocation.x) * Mathf.Rad2Deg;
	}
}
