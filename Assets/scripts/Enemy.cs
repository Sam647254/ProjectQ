using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speedPenalty;
	public float speedBonusOnKill;
	public float movementSpeed;
	public float maxRotation; //eg 1
	public float smoothTurn; //eg 0.5f
	public float wrapWait; //eg 2.5
	float creationTime;
	bool enteredScreen;

	//Velocity movement
	//public int updatesPerMovementUpdate;

	public enum EnemyType {
		ENEMY_NULL,
		ENEMY_WHITE,
		ENEMY_BLUE,
		ENEMY_RED,
		ENEMY_GREEN
	};
	public EnemyType type { get; private set; }
	public bool isHit { get; set; }
	int availableTypes;

	Transform playerTransform;
	RigidbodyPauser pauser;

	//Velocity movement
	//int movementUpdateTimer;

	void Start() {
		pauser = new RigidbodyPauser (rigidbody2D);

		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		//Velocity movement
		//movementUpdateTimer = updatesPerMovementUpdate;
		enteredScreen = false;
		creationTime = Time.time;

		switch ((int)Random.Range (0, availableTypes)) {
		case 0: SetType(EnemyType.ENEMY_WHITE); break;
		case 1: SetType(EnemyType.ENEMY_BLUE); break;
		case 2: SetType(EnemyType.ENEMY_RED); break;
		case 3: SetType(EnemyType.ENEMY_GREEN); break;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Globals.gameSpeed >= 3)
			availableTypes = 3;
		else
			availableTypes = (int) Globals.gameSpeed;

		if (pauser.PauseUpdate ())
			return;
		
		if ((renderer as SpriteRenderer).isVisible)
			enteredScreen = true;
		
					//Velocity movement
		if (!isHit /*&& movementUpdateTimer-- <= 0*/) {

			// don't try to move towards the player if it doesn't exist for whatever reason
			Vector3 targetPos = playerTransform ? targetPlayer() : new Vector3 (-100F, 0F, 0F);
			transform.position = Vector3.MoveTowards (transform.position, targetPos, movementSpeed);

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

			//Velocity movement
			//movementUpdateTimer = updatesPerMovementUpdate;

			// Velocity movement
			/*rigidbody2D.velocity = (Vector2.MoveTowards((Vector2) transform.position,
			                                            (Vector2) targetPos,
			                                            movementSpeed) - 
									(Vector2) transform.position).normalized * movementSpeed;*/
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
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			Globals.modifySpeed(-speedPenalty);
			Destroy(gameObject);
			AudioController.StopAudio();
		}
		else if (collision.gameObject.CompareTag("PlayerAttack")) {
		    isHit = true;
		}
		else if (collision.gameObject.CompareTag("Enemy")) {
			Enemy enemyCollision = collision.gameObject.GetComponent<Enemy>();

			// don't let unhit rockets of different types initiate a pile-up
			if (isHit) {
				enemyCollision.isHit = true;
			}

			if(enemyCollision.type == type && (isHit || enemyCollision.isHit)) {
				Destroy (collision.gameObject);
				Destroy (gameObject);
				Globals.modifySpeed(speedBonusOnKill);
			}
		}
	}

	void SetType(EnemyType newType) {
		type = newType;

		SpriteRenderer spriteRenderer = renderer as SpriteRenderer;

		switch (type) {
		case EnemyType.ENEMY_WHITE:
			spriteRenderer.color = Color.white;
			break;
		case EnemyType.ENEMY_BLUE:
			spriteRenderer.color = Color.blue;
			break;
		case EnemyType.ENEMY_RED:
			spriteRenderer.color = Color.red;
			break;
		case EnemyType.ENEMY_GREEN:
			spriteRenderer.color = Color.green;
			break;
		}
	}
}
