using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speedPenalty;
	public float speedBonusOnKill;
	public float movementSpeed;

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

	Transform playerTransform;

	//Velocity movement
	//int movementUpdateTimer;

	void Start() {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		//Velocity movement
		//movementUpdateTimer = updatesPerMovementUpdate;

		switch (Random.Range (0, (int)Mathf.Floor(Globals.gameSpeed))) {
		case 0: SetType(EnemyType.ENEMY_WHITE); break;
		case 1: SetType(EnemyType.ENEMY_BLUE); break;
		case 2: SetType(EnemyType.ENEMY_RED); break;
		case 3: SetType(EnemyType.ENEMY_GREEN); break;
		}
	}

	// Update is called once per frame
	void Update () {
		// don't try to move towards the player if it doesn't exist for whatever reason
		Vector3 targetPos = playerTransform ? playerTransform.position : new Vector3 (-100F, 0F, 0F);

					//Velocity movement
		if (!isHit /*&& movementUpdateTimer-- <= 0*/) {
			transform.position = Vector3.MoveTowards (transform.position, targetPos, movementSpeed);

			//Velocity movement
			//movementUpdateTimer = updatesPerMovementUpdate;

			// Velocity movement
			/*rigidbody2D.velocity = (Vector2.MoveTowards((Vector2) transform.position,
			                                            (Vector2) targetPos,
			                                            movementSpeed) - 
									(Vector2) transform.position).normalized * movementSpeed;*/
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			Globals.modifySpeed(-speedPenalty);
			Destroy(gameObject);
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
