using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {
	
	public bool roundBumper = true;
	public float bumperForce  = 100f;
	
	void OnCollisionEnter( Collision collision ) {
		if(roundBumper) {
			Vector3 force = collision.contacts[0].point - transform.position;
			force = force.normalized * bumperForce;
			force.y = 0;
		
			collision.rigidbody.AddForce( force, ForceMode.Impulse );
			
			DoAnimation();
		}
		else {
			Vector3 force = new Vector3( 0, 0, bumperForce );
			collision.rigidbody.AddForce( force, ForceMode.Impulse );
		}
	}
	
	void DoAnimation() {
		// Find a "bumper" child, if it exists.
		
		Transform bumper = transform.Find("bumper");
		
		if (bumper) {
			bumper.animation.Play("Active");
		}
	}
}
