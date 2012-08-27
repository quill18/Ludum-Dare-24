using UnityEngine;
using System.Collections;

public class BreedingPitFXScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StopFX ();
	}
	
	public void StopFX(bool a = false) {
		for( int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).gameObject.active = a;
		}
	}
	
	public void StartFX() {
		StopFX(true);
	}
}
