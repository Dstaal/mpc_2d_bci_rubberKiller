using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public List<GameObject> cops = new List<GameObject>();
	public float gameTime = 0f, spawnFrequency = 60f, BlinksPerSecond = 2f;
	private List<GameObject> spawnPoints;
	private float lastSpawn = 0f;

	private GameObject currentCop = null;
	private bool blinking = false;

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
			//else {
			//
			//}
			/*else {
				currentCop.GetComponent<SpriteRenderer>().enabled = !currentCop.GetComponent<SpriteRenderer>().enabled;
			}*/

		}

		if (currentCop != null) {
			if (!blinking) {
				StartCoroutine(Blink ());
			}
		}
	}

	/* blinking cop
	 IEnumerator Blink() {
		if (!blinking) {
			blinking = true;

			Debug.Log ("BLINK ON " + currentCop);
			float waitTime = 1f / BlinksPerSecond;
			while (currentCop != null) {
				Debug.Log ("BLINK");
				currentCop.renderer.enabled = false;
				yield return new WaitForSeconds (waitTime);
				currentCop.renderer.enabled = true;
				yield return new WaitForSeconds (waitTime);
			}
		} else {
			Debug.Log("NOT BLINKING");
		}
	}
	*/

	// blinking silu

	IEnumerator Blink() {
		if (!blinking) {
			blinking = true;
			
			Debug.Log ("BLINK ON " + currentCop);
			float waitTime = 1f / BlinksPerSecond;
			while (currentCop != null) {
				Debug.Log ("BLINK");
				currentCop.transform.GetChild(0).renderer.enabled = false;
				yield return new WaitForSeconds (waitTime);
				currentCop.transform.GetChild(0).renderer.enabled = true;
				yield return new WaitForSeconds (waitTime);
			}
		} else {
			Debug.Log("NOT BLINKING");
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
