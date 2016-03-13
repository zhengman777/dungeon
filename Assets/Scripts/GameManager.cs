using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject player;
	public Camera mainCamera;


	private int rooms = 1;
	private BoardManager boardScript;
	private CameraController cameraController;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		cameraController = mainCamera.GetComponent<CameraController> ();
		InitGame ();
	
	}

	void InitGame () {
		boardScript.SetupScene (rooms);
		GameObject instance = Instantiate (player, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		cameraController.SetPlayer(instance);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
