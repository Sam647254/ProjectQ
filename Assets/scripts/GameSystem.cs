using UnityEngine;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour {

	public enum GameState
	{
		STATE_NULL,
		STATE_MENU,
		STATE_GAME
	};
	public static GameState state = GameState.STATE_MENU;
	public static bool paused { get; set; }

	void Start() {
		Random.seed = ((int)(Time.time * 100F) * 10000019) % 1000000;

		if (Application.loadedLevel == 0)
			state = GameState.STATE_MENU;
		else if (Application.loadedLevel == 1)
			state = GameState.STATE_GAME;
	}

	// Update is called once per frame
	void Update () {
		Globals.score += Globals.gameSpeed * Time.deltaTime;

		if (state == GameState.STATE_GAME && Input.GetButtonUp ("Pause"))
			paused = !paused;
	}
}
