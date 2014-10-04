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
	}

	void Update() {
		if (Input.GetKeyUp("up"))
		{
			ScrollBackground.speed *= 2f;
		}
		if (Input.GetKeyUp("down"))
		{
			ScrollBackground.speed *= 0.5f;
		}
	}
}
