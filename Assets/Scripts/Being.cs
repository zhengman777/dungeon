using UnityEngine;
using System.Collections;

public class Being : MonoBehaviour {

	public float maxHP;
	public float movementSpeed;
	public float strength;

	private float hp;

	// Use this for initialization
	void Start () {
		hp = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
