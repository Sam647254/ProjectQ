﻿using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public float zoomFactor = 1.0f;
	public float initialZoom = 1.0f;
	Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		mainCamera.orthographicSize += zoomFactor * initialZoom;
	}
	
	// Update is called once per frame
	void Update () {
		float scroll = Input.GetAxis("ScrollWheel");
		mainCamera.orthographicSize += scroll * zoomFactor;
	}
}
