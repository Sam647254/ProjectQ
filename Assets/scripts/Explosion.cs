using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Priority";
		Destroy (gameObject, particleSystem.startLifetime);
	}
}
