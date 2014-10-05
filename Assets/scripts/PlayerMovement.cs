using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed; //eg 6

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int mx = 0;
		int my = 0;

		if (Input.GetKey("w"))
			my--;
		if (Input.GetKey ("s"))
			my++;
		if (Input.GetKey ("d"))
			mx--;
		if (Input.GetKey ("a"))
			mx++;

		//normalization factors
		Vector3 normedMovement = new Vector3 (mx, my, 0).normalized;

		transform.position -= new Vector3 (normedMovement.x*moveSpeed*Time.deltaTime, normedMovement.y*moveSpeed*Time.deltaTime, 0);
	}
}
