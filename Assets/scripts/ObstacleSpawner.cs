using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject enemyToSpawn;

	float interval;

	// Use this for initialization
	void Start () {
		Random.seed = 100;
		interval = Random.Range (1F, 3F);
	}
	
	// Update is called once per frame
	void Update () {
		interval -= Time.deltaTime;

		if(interval <= 0F) {
			Instantiate(enemyToSpawn, 
			            Camera.main.ViewportToWorldPoint(new Vector3(1.1F,Random.value,0)),
			            Quaternion.identity);
			interval = Random.Range (1F, 3F);
		}
	}
}
