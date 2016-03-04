using UnityEngine;
using System.Collections;

public class ArrowLauncher : MonoBehaviour {

	public Arrow arrow;
	public float speed;

	private float direction;

	public void Launch (GameObject go) {
		Arrow a = Instantiate (arrow) as Arrow;
		Transform t = a.GetComponent <Transform> ();
		t.position = go.transform.position;
		direction = go.GetComponent <Control> ().AimDirection ();
		Vector3 angle = t.eulerAngles;
		angle.z = direction;
		t.eulerAngles = angle;
		a.velocity = new Vector2 (Mathf.Cos (direction * Mathf.Deg2Rad), Mathf.Sin (direction * Mathf.Deg2Rad)) * speed;
	}
}
