using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	float updateInterval = 3F;
	static int speed;

	// Use this for initialization
	void Start () {
		StartAudio ();
	}
	
	// Update is called once per frame
	void Update () {
		updateInterval -= Time.deltaTime;
		if (updateInterval <= 0) {
			StartAudio ();
			updateInterval = 3F;
		}
	}

	void StartAudio() {
		speed = (int)Mathf.Floor (Globals.gameSpeed);
		if (speed >= 0)
				GameObject.FindWithTag("Audio0").audio.volume = 1F;
		if (speed >= 1)
				GameObject.FindWithTag("Audio1").audio.volume = 1F;
		if (speed >= 2)
				GameObject.FindWithTag("Audio2").audio.volume = 1F;
		if (speed >= 3)
				GameObject.FindWithTag("Audio3").audio.volume = 1F;
		if (speed >= 4)
				GameObject.FindWithTag("Audio4").audio.volume = 1F;
		if (speed >= 5)
				GameObject.FindWithTag("Audio5").audio.volume = 1F;
	}

	public static void StopAudio() {
		speed = (int)Mathf.Floor (Globals.gameSpeed);
		if (speed < 0)
			GameObject.FindWithTag("Audio0").audio.volume = 0F;
		if (speed < 1)
			GameObject.FindWithTag("Audio1").audio.volume = 0F;
		if (speed < 2)
			GameObject.FindWithTag("Audio2").audio.volume = 0F;
		if (speed < 3)
			GameObject.FindWithTag("Audio3").audio.volume = 0F;
		if (speed < 4)
			GameObject.FindWithTag("Audio4").audio.volume = 0F;
		if (speed < 5)
			GameObject.FindWithTag("Audio5").audio.volume = 0F;
	}
}
