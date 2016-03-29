using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count {
		public int maximum;
		public int minimum;

		public Count (int min, int max) {
			minimum = min;
			maximum = max;
		}
	}
		
	public Count pillarCount;
	public GameObject floorTile;
	public GameObject doorTile;
	public GameObject wallTile;
	public GameObject pillarTile;
	public GameObject zombieTile;
	public List <GameObject> enemies = new List<GameObject> ();
	public List <GameObject> doors = new List<GameObject> ();

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List<Vector3>();
	private int roomType;
	private int roomLength;
	private int roomWidth;
	private int roomArea;
	private int roomsNeeded;
	private int roomsMade;
	private int enemyCount;

	void InitializeList() {
		gridPositions.Clear ();


		for (int x = 1; x < roomWidth - 1; x++) {
			for (int y = 1; y < roomLength - 1; y++) {
				gridPositions.Add (new Vector3 (x, y, 0f));
			}
		}
	}

	void BoardSetup() {

		boardHolder = new GameObject ("Board").transform;

		for (roomsMade = 0; roomsMade < roomsNeeded; roomsMade++) {
			roomType = Random.Range (1, 2);

			//Rectangular
			if (roomType == 1) {
				roomLength = Random.Range (8, 17) * 2;
				roomWidth = Random.Range (8, 17) * 2;
				roomArea = roomLength * roomWidth;
				pillarCount = new Count ((int) Mathf.Round(roomArea / 10), (int) Mathf.Round(roomArea / 10));
				for (int x = -1; x < roomWidth + 1; x++) {
					for (int y = -1; y < roomLength + 1; y++) {
						GameObject toInstantiate = floorTile;
						if (x == -1 || x == roomWidth || y == -1 || y == roomLength) {
							if (y == roomLength && (x == roomWidth / 2 -1 || x == roomWidth / 2)) {
								toInstantiate = doorTile;
							} 
							else {
								toInstantiate = wallTile;
							}

						}
						GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
						if (toInstantiate == doorTile) {
							doors.Add (instance);
						}
						instance.transform.SetParent (boardHolder);
					}
				}
			}

			//Cornered
			if (roomType == 2) {

			}
		}
	}
		
	Vector3 RandomPosition() {
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject tile, int minimum, int maximum) {
		int objectCount = Random.Range (minimum, maximum + 1);

		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPosition = RandomPosition ();
			GameObject instance = Instantiate (tile, randomPosition, Quaternion.identity) as GameObject;
			if (tile == zombieTile) {
				enemies.Add (instance);
			}
			instance.transform.SetParent (boardHolder);

		}
	}

	public void SetupScene (int rooms) {
		
		roomsNeeded = rooms;
		enemyCount = 3;

		BoardSetup ();
		InitializeList ();
		LayoutObjectAtRandom (zombieTile, enemyCount, enemyCount);
		LayoutObjectAtRandom (pillarTile, pillarCount.minimum, pillarCount.maximum);

	}
}
