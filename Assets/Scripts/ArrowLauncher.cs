using UnityEngine;
using System.Collections;

public class ArrowLauncher : MonoBehaviour, Weapon {

	public Arrow arrow;
	public float arrowLauncherSpeed;
	public float arrowLauncherSecondsToDestroy;

	public void Activate (GameObject owner) {
		Arrow a = Instantiate (arrow) as Arrow;
		Transform arrowT = a.GetComponent <Transform> ();
		Rigidbody2D arrowRB2D = a.GetComponent <Rigidbody2D> ();

		Transform ownerT = owner.GetComponent <Transform> ();
		Control ownerControl = owner.GetComponent <Control> ();
		Being ownerBeing = owner.GetComponent <Being> ();

		a.direction = ownerControl.AimDirection();
		float arrowPositionX = ownerT.position.x + Mathf.Cos (a.direction * Mathf.Deg2Rad) * .5f;
		float arrowPositionY = ownerT.position.y + Mathf.Sin (a.direction * Mathf.Deg2Rad) * .5f;
		arrowT.position = new Vector3 (arrowPositionX, arrowPositionY, 0);
		Vector3 angle = arrowT.eulerAngles;
		angle.z = a.direction;
		arrowT.eulerAngles = angle;
		arrowRB2D.velocity = new Vector2 (Mathf.Cos (a.direction * Mathf.Deg2Rad), Mathf.Sin (a.direction * Mathf.Deg2Rad)) * arrowLauncherSpeed;

		a.secondsToDestroy = arrowLauncherSecondsToDestroy;
		a.damage = ownerBeing.strength;
		a.owner = owner;
	}
}
