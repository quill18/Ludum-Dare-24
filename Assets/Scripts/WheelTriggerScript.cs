using UnityEngine;
using System.Collections;

public class WheelTriggerScript : MonoBehaviour {
	
	float wheelSpinDuration = 5f;
	float wheelSpinLeft = 0;
	public Transform wheel;
	HingeJoint wheelHingeJoint;
	bool toastedOnce = false;
	
	// Use this for initialization
	void Start () {
		wheelHingeJoint = wheel.hingeJoint;
	}
	
	// Update is called once per frame
	void Update () {
		if(wheelSpinLeft > 0) {
			wheelSpinLeft -= Time.deltaTime;
		}
		
		if(wheelSpinLeft <= 0) {
			wheelHingeJoint.useMotor = false;
			gameObject.GetComponent<DropTargetScript>().ResetTarget();
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.rigidbody.tag == "Ball") {
			wheelSpinLeft = wheelSpinDuration;
			wheelHingeJoint.useMotor = true;
			
			if(!toastedOnce) {
				ToastManagerScript.Instance.ShowToast(ToastManagerScript.Instance.texWheelOfMutation);
				toastedOnce = true;
			}
		}
	}
}
