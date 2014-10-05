using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1.0f;
	public float lifeTime;

	float lifeTimer;
	RigidbodyPauser pauser;

	void Start() {
		pauser = new RigidbodyPauser (rigidbody2D);
		lifeTimer = lifeTime;
	}

	void Update() {

		if (pauser.PauseUpdate ())
			return;

		lifeTimer -= Time.deltaTime;

		if (lifeTimer <= 0f)
			Destroy(gameObject);
	}

	public void setPos(Vector3 pos) {
		transform.position = pos;
	}

	public void setDir(Vector2 dir) {
		rigidbody2D.velocity = speed * dir;
	}

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Enemy")) {
			Enemy colEnemy = collision.gameObject.GetComponent<Enemy>();
			colEnemy.Hit ();
		    Destroy (gameObject);
		}
	}
}
