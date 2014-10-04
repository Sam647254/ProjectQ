﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class ScrollBackground : MonoBehaviour
{
	Transform cameraTransform;
	float spriteWidth;

	public static float speed = 10f;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		spriteWidth = (renderer as SpriteRenderer).sprite.bounds.size.x * transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (speed * Globals.gamespeed * Time.deltaTime, 0);

		if (transform.position.x + spriteWidth < cameraTransform.position.x) {
			transform.position = new Vector3(transform.position.x + spriteWidth * 2,
			                                 transform.position.y);
		}

	}
}
