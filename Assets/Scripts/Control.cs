using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	private Transform t;
	private Being being;
	private Rigidbody2D rb2d;
	public IWeapon weapon;
	private GameObject owner;


	// Use this for initialization
	void Start () {
		t = GetComponent <Transform> ();
		being = GetComponent <Being> ();
		rb2d = GetComponent <Rigidbody2D> ();
		weapon = GetComponent <ArrowLauncher> ();
		owner = gameObject;
	}

	void Update () {
		if (Input.GetMouseButtonUp (0) == true) {
			weapon.Activate (owner);
		}
	}

	void FixedUpdate () {
		Vector2 bVec = new Vector2 (Input.GetAxis ("Horizontal"),Input.GetAxis ("Vertical"));
		bVec.Normalize ();
		rb2d.velocity = bVec * being.movementSpeed;
	}

	public float AimDirection () {
		Vector2 mouseLocation = ((Vector2) Camera.main.ScreenToWorldPoint (Input.mousePosition));
		mouseLocation = mouseLocation - ((Vector2) t.position);
		return Mathf.Atan2 (mouseLocation.y, mouseLocation.x) * Mathf.Rad2Deg;
	}
		
}
