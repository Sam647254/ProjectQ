using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnGUI() {

		if (GameSystem.state != GameSystem.GameState.STATE_MENU)
			return;

		float col = Screen.width / 12;
		float row = Screen.height / 12;

		if (GUI.Button(new Rect(col * 5.5f, row * 6f, col, row), "Start")) {
			Application.LoadLevel(1);
			GameSystem.state = GameSystem.GameState.STATE_GAME;
		}
		if (GUI.Button(new Rect(col * 5.5f, row * 8f, col, row), "Quit"))
			Application.Quit();
	}

}
