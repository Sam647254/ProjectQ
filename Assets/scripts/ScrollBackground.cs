using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class ScrollBackground : MonoBehaviour
{
	public float speed = 1.0f;
	Transform cameraTransform;
	float spriteWidth;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		spriteWidth = GetComponent<SpriteRenderer> ().sprite.bounds.size.x;

		Debug.Log ("spriteWidth: " + spriteWidth);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (speed, 0);

		if (transform.position.x + spriteWidth < cameraTransform.position.x) {
			transform.position = new Vector3(transform.position.x + spriteWidth * 2,
			                                 transform.position.y);
		}
	}
}
