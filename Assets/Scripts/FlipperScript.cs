using UnityEngine;
using System.Collections;

public class FlipperScript : MonoBehaviour {

	public string buttonName = "RightFlipper";
//	public int torqueDirection = 1;
	
	float realForce;
	float realVelocity;
	
	// Use this for initialization
	void Start () {
		realVelocity = hingeJoint.motor.targetVelocity;
		realForce = hingeJoint.motor.force;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		JointMotor m = hingeJoint.motor;
		
		if( Input.GetButtonDown(buttonName) ) {
			audio.Play();
		}
		
		if( Input.GetButton(buttonName) ) {
			m.targetVelocity = realVelocity;
			m.force = realForce;
		}
		else {
			m.targetVelocity = -realVelocity;
			m.force = realForce * .25f;
		}
		
		hingeJoint.motor = m;
	}
}
