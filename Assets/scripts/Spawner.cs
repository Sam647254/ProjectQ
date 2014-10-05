using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public float minInterval;
	public float maxInterval;
	public List<Rect> spawnRegions;
	public GameObject spawnObject;

	float interval;

	// Use this for initialization
	void Start () {
		interval = maxInterval;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameSystem.paused || GameSystem.state != GameSystem.GameState.STATE_GAME)
			return;

		interval -= Globals.gameSpeed * Time.deltaTime;

		if(interval <= 0F) {
			Rect spawnRegion = spawnRegions[Random.Range(0, spawnRegions.Count)];

			Instantiate(spawnObject,
			            new Vector3(Random.Range (spawnRegion.xMin, spawnRegion.xMax),
			            			Random.Range (spawnRegion.yMin, spawnRegion.yMax)),
			            Quaternion.identity);
			interval = Random.Range (minInterval, maxInterval);
		}
	}
}
