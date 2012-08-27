using UnityEngine;
using System.Collections;

public class BallColorScript : MonoBehaviour {
	
	static Color evolvedColor = new Color(0, 1f, 0);
	static bool didEvolvedOnce = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void UseEvolvedColor() {
		transform.Find ("BallModel").renderer.material.color = evolvedColor; //new Color(0, 1f, 0);
	}
	
	public void RandomizeColor() {
		Debug.Log ("RandomizeColor");
		
		Color currentColor = transform.Find ("BallModel").renderer.material.color;
		
		int r = Random.Range(0, 2);
		
		if(r == 0) {
			currentColor.r = Random.Range(.5f, 1f);
		}
		else if(r == 1) {
			currentColor.g = Random.Range(.5f, 1f);
		}
		else {
			currentColor.b = Random.Range(.5f, 1f);
		}
		transform.Find ("BallModel").renderer.material.color = currentColor;
	}
	
	public void MakeEvolvedColor() {
		evolvedColor = transform.Find ("BallModel").renderer.material.color;
	}
	
}
