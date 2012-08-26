using UnityEngine;
using System.Collections;

public class LightBulbScript : MonoBehaviour {
	
	bool isOn = false;
	public bool IsOn {
		get {
			return isOn;
		}
	}
	
	void Start() {
		TurnOff();
	}
	
	public void TurnOn() {
		transform.Find ("lightBulb").renderer.materials[1].color = new Color(1, 1, 1);
		isOn = true;
	}
	
	public void TurnOff() {
		transform.Find ("lightBulb").renderer.materials[1].color = new Color(.25f, .25f, .25f);
		isOn = false;
	}
	
	
}
