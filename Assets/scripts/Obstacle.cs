using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private float speed;
	private float spriteWidth;
	private static bool collided = false;

	// Use this for initialization
	void Start () {
		speed = ScrollBackground.speed;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3 (speed, 0);
	}

	void OnBecomeInvisible() {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		collided = true;
	}

	public void setSpeed(float newSpeed) {
		speed = newSpeed;
	}

	public float getSpeed() {
		return speed;
	}

	public void setCollided(bool col) {
		collided = col;
	}

	public bool getCollided() {
		return collided;
	}
}
