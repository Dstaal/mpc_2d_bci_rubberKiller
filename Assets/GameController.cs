using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public List<GameObject> cops = new List<GameObject>();
	public float gameTime = 0f, spawnFrequency = 60f;
	private List<GameObject> spawnPoints;
	private float lastSpawn = 0f;

	private GameObject currentCop = null;

	// Use this for initialization
	void Start () {
		spawnPoints = new List<GameObject>( GameObject.FindGameObjectsWithTag("sp") );

		spawnCop ();
	}
	
	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;

		if (gameTime - lastSpawn > spawnFrequency) {
			lastSpawn = gameTime;

			if (currentCop == null) {
				spawnCop();
			}

		}
	}

	private void spawnCop() {
		GameObject spawnPoint = getRandomSpawnPoint();
		GameObject cop = getRandomCop ();

		GameObject newCop = Instantiate (cop) as GameObject;

		newCop.transform.position = spawnPoint.transform.position;
		newCop.transform.localScale = spawnPoint.transform.localScale;

		currentCop = newCop;

	}

	private GameObject getRandomSpawnPoint() {
		return spawnPoints[Random.Range(0, spawnPoints.Count)];
	}

	private GameObject getRandomCop() {
		return cops [Random.Range (0, cops.Count)];
	}
}
