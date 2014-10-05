using UnityEngine;
using System.Collections;

public class StatTracker : MonoBehaviour {

	public static int projectiles = 0;
	public static int collisions = 0;
	public static int timesHit = 0;
	public static float maxSpeed = 0;
	public static int white = 0, blue = 0, red = 0, green = 0;

	public static void updateMaxSpeed() {
		Debug.Log ("Max Speed Record!");
		if(Globals.gameSpeed > maxSpeed)
			maxSpeed = Globals.gameSpeed;
	}

	public static int GOD_DAMN_IT() {
		if (timesHit == 0)
			return 1;
		else
			return timesHit;
	}
}
