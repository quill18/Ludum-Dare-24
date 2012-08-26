using UnityEngine;
using System.Collections;

public class SuicideRolloverScript : MonoBehaviour {
	
	public Transform lightBulb;
	public int bonusValue = 100;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Ball") {
			LightBulbScript lbs = lightBulb.GetComponent<LightBulbScript>();
			if(lbs.IsOn) 
				ScoreManagerScript.Instance.AddScore(bonusValue);
		}
	}
}
