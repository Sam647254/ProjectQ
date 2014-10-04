using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1.0f;
	public float lifeTime = 1.0f;

	void Start() {
		Destroy (gameObject, lifeTime);
	}

	public void setPos(Vector3 pos) {
		transform.position = pos;
	}

	public void setDir(Vector2 dir) {
		rigidbody2D.velocity = speed * dir;
	}

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Enemy"))
		    Destroy (gameObject);
	}
}
