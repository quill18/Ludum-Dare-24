using UnityEngine;
using System.Collections;

public class ScoreOnCollisionScript : MonoBehaviour {
	
	public int scoreValue = 1;
	public bool onlySpinner = false;

	void OnCollisionEnter(Collision collision) {
		if(collision.rigidbody.tag == "Ball") {
			Debug.Log (ScoreManagerScript.Instance);
			ScoreManagerScript.Instance.AddScore(scoreValue);
		}
	}

	void OnTriggerEnter(Collider other) {
		if( (onlySpinner==false && other.tag == "Ball") || other.tag == "Spinner") {
			ScoreManagerScript.Instance.AddScore(scoreValue);
		}
	}
}
