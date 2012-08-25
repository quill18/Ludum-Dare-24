using UnityEngine;
using System.Collections;

public class PlungerScript : MonoBehaviour {
	
	public float pullForceIncreasePerSecond = 80000f;
	public float pullForceLimit = 75000f;
	
	float pullForce = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if( Input.GetButton("Plunger") ) {
			pullForce += pullForceIncreasePerSecond * Time.deltaTime;
			if(pullForce > pullForceLimit) {
				pullForce = pullForceLimit;
			}
			
			rigidbody.AddForce( 0, 0, -pullForce );
		}
		else {
			pullForce = 0;
		}
	}
}
