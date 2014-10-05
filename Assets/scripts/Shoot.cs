using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Projectile projectileType;
	public string button;
	
	// Update is called once per frame
	void Update () {
		if (!GameSystem.paused && Input.GetButtonUp (button)) {

			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			DoShoot (transform.position, (new Vector2(mousePos.x - transform.position.x,
			                                          mousePos.y - transform.position.y)).normalized);
		}
	}

	void DoShoot(Vector3 pos, Vector2 dir) {
		//Debug.Log ("shoot, pos=(" + pos.x + ", " + pos.y + "), dir=(" + dir.x + ", " + dir.y + ")");
		Projectile shot = (Projectile) (Instantiate (projectileType));
		shot.setPos (pos);
		shot.setDir (dir);
	}
}
