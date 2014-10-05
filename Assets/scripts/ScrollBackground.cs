using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class ScrollBackground : MonoBehaviour
{
	public static float speed = 10f;

	Transform cameraTransform;
	float spriteWidth;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		spriteWidth = (renderer as SpriteRenderer).sprite.bounds.size.x * transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameSystem.paused)
			return;

		transform.position -= new Vector3 (speed * Globals.gameSpeed * Time.deltaTime, 0);

		if (transform.position.x + spriteWidth < cameraTransform.position.x) {
			transform.position = new Vector3(transform.position.x + spriteWidth * 2,
			                                 transform.position.y);
		}

		/*if (Input.GetKeyUp("up"))
		{
			scrollSpeed *= 2f;
		}
		if (Input.GetKeyUp("down"))
		{
			scrollSpeed *= 0.5f;

		}*/
	}
}
