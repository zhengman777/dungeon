using UnityEngine;
using System.Collections;

public class ArrowLauncher : MonoBehaviour {

	public Arrow arrow;
	public float arrowLauncherSpeed;
	public float arrowLauncherSecondsToDestroy;

	public void Launch (Vector3 position, float direction, float damage) {
		Arrow a = Instantiate (arrow) as Arrow;
		Transform t = a.GetComponent <Transform> ();
		t.position = position;
		Vector3 angle = t.eulerAngles;
		angle.z = direction;
		t.eulerAngles = angle;
		a.velocity = new Vector2 (Mathf.Cos (direction * Mathf.Deg2Rad), Mathf.Sin (direction * Mathf.Deg2Rad)) * arrowLauncherSpeed;
		a.direction = direction;
		a.secondsToDestroy = arrowLauncherSecondsToDestroy;
		a.damage = damage;
	}
}
