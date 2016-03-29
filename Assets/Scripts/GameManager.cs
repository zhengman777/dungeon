using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject player;
	public int currentRoom;

	private int rooms = 1;
	private BoardManager boardScript;
	private CameraController cameraController;

	// Use this for initialization
	void Awake () {
		currentRoom = 1;
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		cameraController = Camera.main.GetComponent<CameraController> ();

		InitGame ();
	
	}

	void InitGame () {
		boardScript.SetupScene (rooms);
		GameObject instance = Instantiate<GameObject>(player);
		cameraController.SetPlayer(instance);
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (GameObject.FindGameObjectsWithTag ("Enemy").Length);
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			for (int i = currentRoom - 1; i < currentRoom + 1; i++) {
				GameObject targetDoor = boardScript.doors [i];
				Destroy (targetDoor);
			}
				
		}
	}
}
