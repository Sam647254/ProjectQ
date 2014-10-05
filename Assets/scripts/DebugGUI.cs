using UnityEngine;
using System.Collections;

public class DebugGUI : MonoBehaviour {

	void Start() {
	}

	void OnGUI() {
		GUI.color = Color.black;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		GUI.Label (new Rect (10, 10, 500, 20),
		           "mouse world pos: (" + mousePos.x + ", " + mousePos.y + ")");
		GUI.Label (new Rect (10, 30, 500, 20),
		           "game speed: " + Globals.gameSpeed);
		GUI.Label (new Rect (10, 50, 500, 20), "Projectiles: " + StatTracker.projectiles);
		GUI.Label (new Rect (10, 70, 500, 20), "Collisions: " + StatTracker.collisions);
		GUI.Label (new Rect (10, 90, 500, 20), "Times hit: " + StatTracker.timesHit);
		GUI.Label (new Rect (10, 110, 500, 20), "Generated rockets: " + (StatTracker.white+StatTracker.blue+StatTracker.red+StatTracker.green));
		GUI.Label (new Rect (10, 130, 500, 20), "Kill/Death ratio: " + ((float)StatTracker.collisions/StatTracker.GOD_DAMN_IT()));
	}
}
