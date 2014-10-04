using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	public static float distance = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		distance += ScrollBackground.speed * Globals.gamespeed * Time.deltaTime;
	}
}
