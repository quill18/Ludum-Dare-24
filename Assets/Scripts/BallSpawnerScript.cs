using UnityEngine;
using System.Collections;

public class BallSpawnerScript : MonoBehaviour {

	public GameObject ballObject;

	// Use this for initialization
	void Start () {
		SpawnBall ();	
	}
	
	public void SpawnBall(bool randomizeColor = false) {
		GameObject ball = (GameObject)Instantiate(ballObject, transform.position, transform.rotation);
		BallColorScript bcs = ball.GetComponent<BallColorScript>();
		
		if(randomizeColor) {
			bcs.UseEvolvedColor();
			bcs.RandomizeColor();
		}
		else {
			bcs.UseEvolvedColor();
		}
	}
	
}
