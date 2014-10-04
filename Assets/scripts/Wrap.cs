using UnityEngine;
using System.Collections;

public class Wrap : MonoBehaviour {

	protected float oldX;
	protected float oldY;
	protected float spriteWidth;
	protected float spriteHeight;

	// Use this for initialization
	void Start () {
		oldX = transform.position.x;
		oldY = transform.position.y;

		spriteWidth = (renderer as SpriteRenderer).sprite.bounds.size.x * transform.localScale.x;
		spriteHeight = (renderer as SpriteRenderer).sprite.bounds.size.y * transform.localScale.y;
	}

	void Update() {
		float delX = transform.position.x - oldX;
		float delY = transform.position.y - oldY;
		
		oldX = transform.position.x;
		oldY = transform.position.y;

		if (transform.position.x + spriteWidth/2 < -Globals.camWidth()/2 && delX < 0)  {
			transform.position += new Vector3(Globals.camWidth()+spriteWidth, 0, 0);
			Debug.Log ("move to right of screen");
		} else if (transform.position.x - spriteWidth/2 > Globals.camWidth()/2 && delX > 0) {
			transform.position -= new Vector3(Globals.camWidth()+spriteWidth, 0, 0);
			Debug.Log ("move to left of screen");
		}
		
		if (transform.position.y + spriteHeight/2 < -Globals.camHeight()/2 && delY < 0)  {
			transform.position += new Vector3(0, Globals.camHeight() + spriteHeight, 0);
			Debug.Log ("move to top of screen");
		} else if (transform.position.y - spriteHeight/2 > Globals.camHeight()/2 && delY > 0) {
			transform.position -= new Vector3(0, Globals.camHeight() + spriteHeight, 0);
			Debug.Log ("move to bottom of screen");
		}
	}

}
