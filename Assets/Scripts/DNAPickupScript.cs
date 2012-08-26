using UnityEngine;
using System.Collections;

public class DNAPickupScript : MonoBehaviour {
	
	public int bonusValue = 50;
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Ball") {
			Debug.Log ("DNA Picked Up!!");
			GATCScript.ResetGATCTargets();
			//BallColorScript bcs = collision.rigidbody.GetComponent<BallColorScript>();
			//bcs.RandomizeColor();
			//bcs.MakeEvolvedColor();
			
			//ScoreManagerScript.Instance.IncreaseBonusMultiplier();
			ScoreManagerScript.Instance.AddBonus(bonusValue);
			ToastManagerScript.Instance.ShowToast(ToastManagerScript.Instance.texDNACollected);
			
			Destroy(gameObject);
		}
	}
	
	void LifeReset() {
		Destroy (gameObject);
	}
}
