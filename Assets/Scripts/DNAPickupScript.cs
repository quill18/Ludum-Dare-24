using UnityEngine;
using System.Collections;

public class DNAPickupScript : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		if(collision.rigidbody.tag == "Ball") {
			Debug.Log ("DNA Picked Up!!");
			GATCScript.ResetGATCTargets();
			BallColorScript bcs = collision.rigidbody.GetComponent<BallColorScript>();
			bcs.RandomizeColor();
			bcs.MakeEvolvedColor();
		}
	}
}
