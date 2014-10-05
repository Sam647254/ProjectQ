using UnityEngine;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour {

	public static bool paused { get; set; }

	// Update is called once per frame
	void Update () {
		Globals.score += Globals.gameSpeed * Time.deltaTime;

		if (Input.GetKeyUp (KeyCode.P))
			paused = !paused;
	}
}
