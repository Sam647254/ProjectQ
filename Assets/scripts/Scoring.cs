using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Globals.score += Globals.gameSpeed * Time.deltaTime;
	}
}
