using UnityEngine;
using System.Collections;

public class Enemy : Obstacle {

	public float speedPenalty;
	public float speedBonusOnKill;
	public float movementSpeed;
	Transform playerTransform;

	void Start() {
		setSpeed (ScrollBackground.speed);
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("

		transform.position = Vector3.MoveTowards (transform.position, playerTransform.position, movementSpeed);

//		if (getCollided() == true)
//			Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			Globals.modifySpeed(-speedPenalty);
			Destroy(gameObject);
		}
		else if (collision.gameObject.CompareTag("PlayerAttack")) {
			Globals.modifySpeed(speedBonusOnKill);
			Destroy(gameObject);
		}
	}
}
