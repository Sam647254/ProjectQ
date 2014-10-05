using UnityEngine;
using System.Collections;

public class FakeEnemy : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
	}
}
