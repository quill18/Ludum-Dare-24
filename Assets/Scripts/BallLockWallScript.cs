using UnityEngine;
using System.Collections;

public class BallLockWallScript : MonoBehaviour {

	public GameObject breedingPitFX;
	
	/*void OnCollisionEnter(Collision collision) {
		if(collision.rigidbody.tag=="Ball") {
			LowerWall();
		}
	}*/
	
	bool isDown = false;
	
	public void LowerWall() {
		if(!isDown) {
			isDown = true;
			transform.Translate(0, -3f, 0);
			ToastManagerScript.Instance.ShowToast(ToastManagerScript.Instance.texBreedingGround);
			breedingPitFX.GetComponent<BreedingPitFXScript>().StartFX();
		}
	}
	
	public void TotalReset() {
		Vector3 pos = transform.position;
		pos.y = 0;
		transform.position = pos;
		isDown = false;
		breedingPitFX.GetComponent<BreedingPitFXScript>().StopFX();
	}
}
