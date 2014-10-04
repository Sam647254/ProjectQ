using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	public float distanceMoved = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		distanceMoved += ScrollBackground.speed * Globals.gamespeed * Time.deltaTime;
	}
}
