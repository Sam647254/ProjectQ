using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speedPenalty;
	public float speedBonusOnKill;
	public float movementSpeed;
	public float maxRotation; //eg 1
	public float smoothTurn; //eg 0.5f
	public float wrapWait; //eg 2.5
	public float restartTime;
	public GameObject explosion;

	public enum EnemyType {
		ENEMY_NULL,
		ENEMY_WHITE,
		ENEMY_BLUE,
		ENEMY_RED,
		ENEMY_GREEN
	};
	public EnemyType type { get; private set; }
	public bool isHit { get; set; }
	
	float creationTime;
	bool enteredScreen;
	float whenToRestart;
	bool exploded;

	Transform playerTransform;
	RigidbodyPauser pauser;

	void Start() {
		pauser = new RigidbodyPauser (rigidbody2D);

		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		exploded = false;
		enteredScreen = false;
		creationTime = Time.time;

		chooseType ();
	}

	// Update is called once per frame
	void Update () {
		if (pauser.PauseUpdate ()) {
			
			if (!particleSystem.isPaused) {
				particleSystem.Pause();
				particleSystem.Clear();
			}
			return;
		}
		else if (particleSystem.isPaused)
			particleSystem.Play();
		
		if ((renderer as SpriteRenderer).isVisible)
			enteredScreen = true;

		if (!isHit) {

			// don't try to move towards the player if it doesn't exist for whatever reason
			Vector3 targetPos = playerTransform ? targetPlayer() : new Vector3 (-100F, 0F, 0F);
			//transform.position = Vector3.MoveTowards (transform.position, targetPos, movementSpeed);
			rigidbody2D.velocity = (Vector3.MoveTowards(transform.position, targetPos, movementSpeed)
			                        - transform.position).normalized
								   * movementSpeed;

			//rotation
			//get angle between this object and player, and subtract current angle, normalize
			float absAngle = Mathf.Atan((targetPos.y-transform.position.y) /
			                            (targetPos.x-transform.position.x)) * 180/Mathf.PI;
			if (targetPos.x > transform.position.x)
				absAngle += 180;
			float relAngle = absAngle - transform.eulerAngles.z;
			while (relAngle < -180)
				relAngle += 360;
			while (relAngle > 180)
				relAngle -= 360;
			
			//smooth out rotation - turn slower when we're almost there
			relAngle *= smoothTurn * Time.deltaTime;
			
			//prevent from rotating more than the maxangle each update
			if (Mathf.Abs (relAngle) > maxRotation * Time.deltaTime) {
				relAngle = Mathf.Sign (relAngle) * maxRotation;
			}
			
			transform.Rotate(new Vector3(0,0, relAngle));
		}
		else if (Time.time >= whenToRestart) {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.angularVelocity = 0F;
			isHit = false;
			particleSystem.enableEmission = true;
		}
	}

	//account for screen wrapping
	//check all combinations of wrapping (and not wrapping) to find fastest path to player
	Vector3 targetPlayer() {
		//Debug.Log ("current: " + Time.time + ", wait: " + (creationTime+wrapWait));
		Vector3 targetPos = playerTransform.position;

		//don't let seeking wrap before enemy enters screen
		if (!enteredScreen || Time.time < creationTime + wrapWait)
			return targetPos;
		float bestDistance = (targetPos - transform.position).magnitude;
		for (int ix = -1; ix <= 1; ix++) {
			for (int iy = -1; iy <= 1; iy++) {
				if (ix != 0 || iy != 0) {
					Vector3 tmpPos = targetPos + new Vector3(ix*Globals.camWidth(), iy*Globals.camHeight(), 0);
					float tmpDistance = (tmpPos - transform.position).magnitude;
					if (tmpDistance < bestDistance) {
						bestDistance = tmpDistance;
						targetPos = tmpPos;
					}
				}
			}
		}
		return targetPos;
	}

	public void Hit() {
		if (!isHit)
			whenToRestart = Time.time + restartTime;

		isHit = true;

		particleSystem.enableEmission = false;
	}

	// create an explosion upon collision with player
	public void Explode(ContactPoint2D point) {
		// don't explode twice (for whatever reason)
		if (exploded)
			return;

		exploded = true;

		Instantiate (explosion, point.point, Quaternion.identity);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
<<<<<<< HEAD
			StatTracker.timesHit++;
=======
			Explode(collision.contacts[0]);
>>>>>>> FETCH_HEAD
			Globals.modifySpeed(-speedPenalty);
			AudioController.StopAudio();
			Destroy(gameObject);
		}
		else if (collision.gameObject.CompareTag("PlayerAttack")) {
			Hit ();
		}
	}
	
	void OnCollisionStay2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Enemy")) {
			Enemy enemyCollision = collision.gameObject.GetComponent<Enemy>();

			// don't let unhit rockets of different types initiate a pile-up
			if (isHit) {
				enemyCollision.Hit();
			}

			if(enemyCollision.type == type && (isHit || enemyCollision.isHit)) {
				StatTracker.collisions++;
				Destroy (collision.gameObject);
				Destroy (gameObject);
				Globals.modifySpeed(speedBonusOnKill);
				StatTracker.updateMaxSpeed();
			}
		}
	}

	void chooseType() {
		SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
		int colourIndex;
		int gameSpeedInt = Mathf.FloorToInt (Globals.gameSpeed);

		if (gameSpeedInt < 4)
			colourIndex = Random.Range(0, gameSpeedInt);
		else
			colourIndex = Random.Range(0, 4);

		switch (colourIndex) {
		case 0:
			type = EnemyType.ENEMY_WHITE;
			spriteRenderer.color = Color.white;
			StatTracker.white++;
			break;
		case 1:
			type = EnemyType.ENEMY_BLUE;
			spriteRenderer.color = Color.blue;
			StatTracker.blue++;
			break;
		case 2:
			type = EnemyType.ENEMY_RED;
			spriteRenderer.color = Color.red;
			StatTracker.red++;
			break;
		case 3:
			type = EnemyType.ENEMY_GREEN;
			spriteRenderer.color = Color.green;
			StatTracker.green++;
			break;
		}
	}
}
