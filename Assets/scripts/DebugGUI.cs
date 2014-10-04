﻿using UnityEngine;
using System.Collections;

public class DebugGUI : MonoBehaviour {

	private float speed = ScrollBackground.speed;

	void Start() {
	}

	void OnGUI() {
		GUI.color = Color.black;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		GUI.Label (new Rect (10, 10, 500, 20),
		           "mouse world pos: (" + mousePos.x + ", " + mousePos.y + ")");
		GUI.Label (new Rect (30, 30, 500, 20), "Background scrolling speed: " + speed);
		GUI.Label (new Rect (50, 50, 500, 20), "Total seconds: " + Time.time);
	}
}
