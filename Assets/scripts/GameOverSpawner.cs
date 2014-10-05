using UnityEngine;
using System.Collections;

public class GameOverSpawner : Spawner {
	
	// Update is called once per frame
	public override void Update () {
		if (Globals.score > Globals.finishLine || (Input.GetKey("l") && Input.GetKey("="))) {
			base.Update ();
		}
	}
}
