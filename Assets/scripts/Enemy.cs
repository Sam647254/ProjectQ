using UnityEngine;
using System.Collections;

public class Enemy : Obstacle {

	public Transform playerTransform;

	void Start() {
		setSpeed (ScrollBackground.speed);
		playerTransform = GameObject.Find ("player").transform;
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, playerTransform.position, 0.5F);

//		if (getCollided() == true)
//			Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy(gameObject);
	}
}
