using UnityEngine;
using System.Collections;

public class BallTiltScript : MonoBehaviour {
	
	float minX = -50f;
	float maxX = 50f;
	float maxZ = 50f;
	
	public void DoTilt() {
		rigidbody.AddForce( Random.Range(minX, maxX), 0, Random.Range(0, maxZ), ForceMode.Impulse);
	}
}
