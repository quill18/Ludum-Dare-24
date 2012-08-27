using UnityEngine;
using System.Collections;

public class BouncyBallScript : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
		rigidbody.AddForce(Random.insideUnitSphere * 10f, ForceMode.Impulse);
	}
}
