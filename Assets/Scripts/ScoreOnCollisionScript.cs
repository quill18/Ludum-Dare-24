using UnityEngine;
using System.Collections;

public class ScoreOnCollisionScript : MonoBehaviour {
	
	public int scoreValue = 1;
	public int bonusValue = 0;
	
	public bool onlySpinner = false;
	public bool increaseBonusMultiplier = false;

	void OnCollisionEnter(Collision collision) {
		if(collision.rigidbody.tag == "Ball") {
			ScoreManagerScript.Instance.AddScore(scoreValue);
			ScoreManagerScript.Instance.AddBonus(bonusValue);
		}
	}

	void OnTriggerEnter(Collider other) {
		if( (onlySpinner==false && other.tag == "Ball") || other.tag == "Spinner") {
			ScoreManagerScript.Instance.AddScore(scoreValue);
			ScoreManagerScript.Instance.AddBonus(bonusValue);
			
			if(increaseBonusMultiplier)
				ScoreManagerScript.Instance.IncreaseBonusMultiplier();
		}
	}
}
