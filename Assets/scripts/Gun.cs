using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	Transform playerTransform;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameSystem.paused)
			return;
		if (playerTransform) {
			transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y+0.2f, playerTransform.position.z);

			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//get angle between this object and player, and subtract current angle, normalize
			float absAngle = Mathf.Atan((mousePos.y-transform.position.y) /
			                            (mousePos.x-transform.position.x)) * 180/Mathf.PI;
			if (mousePos.x > transform.position.x)
				absAngle += 180;

			float relAngle = absAngle - transform.eulerAngles.z;
			while (relAngle < -180)
				relAngle += 360;
			while (relAngle > 180)
				relAngle -= 360;

			Debug.Log (mousePos);
			Debug.Log (absAngle);
			Debug.Log (relAngle);
			transform.Rotate(new Vector3(0,0, relAngle));
		}
	}
}
