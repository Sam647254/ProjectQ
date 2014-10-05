using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	float column = Screen.width / 12;
	float row = Screen.height / 12;
	Texture2D blackBG;

	void initTexure() {
		blackBG = new Texture2D(1,1);
		blackBG.SetPixel(1,1,new Color(1,1,1,0.5F));
	}

	void OnGUI() {
		if (GameSystem.paused) {
			GUI.Box(new Rect(0,0, Screen.width, Screen.height),blackBG);

			if (GUI.Button(new Rect(column * 5.5F-5F, row * 6F, column+10F, row), "Continue"))
				GameSystem.paused = false;
			if (GUI.Button(new Rect(column * 5.5F, row * 7F, column, row), "Restart")) {
				GameSystem.paused = false;
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(column * 5.5F, row * 8F, column, row), "Quit")) {
				Application.LoadLevel(0);
				GameSystem.paused = false;
			}
		}
	}
}
