using UnityEngine;
using System.Collections;

public class Being : MonoBehaviour {

	public float maxHP;
	public float hp;
	public float movementSpeed;
	public float strength;

	// Use this for initialization
	void Start () {
		hp = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}
}
