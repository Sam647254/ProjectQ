﻿using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

	public static float gameSpeed = 1.0f;
	public static float score = 0.0f;
	static float minSpeed = 0.5f;

	public static void modifySpeed(float offset) {
		gameSpeed += offset;
		if (gameSpeed < minSpeed)
			gameSpeed = minSpeed;
	}

	public static float camHeight() {
		return 2f * Camera.main.orthographicSize;
	}

	public static float camWidth() {
		return 2f * Camera.main.orthographicSize * Camera.main.aspect;
	}
}
