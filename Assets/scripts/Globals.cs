using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	
	public static float gameSpeed = 2.0f;
	public static float score = 0.0f;
	public static float finishLine = 100;
	static float minSpeed = 1.5f;

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
