using UnityEngine;

public class RigidbodyPauser {
	
	bool pausedLastUpdate = false;
	Vector2 velocityBeforePause = Vector2.zero;
	float angVelocityBeforePause = 0f;
	Rigidbody2D rb;

	// don't use default constructor
	private RigidbodyPauser() {
	}

	public RigidbodyPauser(Rigidbody2D newRb) {
		rb = newRb;
	}

	// returns true if game is paused
	public bool PauseUpdate() {

		if (GameSystem.paused) {
			if (!pausedLastUpdate) {
				pausedLastUpdate = true;
				velocityBeforePause = rb.velocity;
				angVelocityBeforePause = rb.angularVelocity;
				rb.Sleep();
			}

			return true;
		}
		else {
			if (pausedLastUpdate) {
				pausedLastUpdate = false;
				rb.WakeUp();
				rb.velocity = velocityBeforePause;
				rb.angularVelocity = angVelocityBeforePause;
			}

			return false;
		}
	}
}
