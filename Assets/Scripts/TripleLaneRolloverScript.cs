using UnityEngine;
using System.Collections;

public class TripleLaneRolloverScript : MonoBehaviour {

	bool wasTriggered = false;
	public Transform lightBulb;
	
	static int numberTriggered = 0;
	
	public Transform[] suicideLaneRolloverLightbulbs;
	
	void OnTriggerEnter(Collider other) {
		if(!wasTriggered && other.tag == "Ball") {
			wasTriggered = true;
			numberTriggered++;
			LightBulbScript lbs = lightBulb.GetComponent<LightBulbScript>();
			lbs.TurnOn();
			
			if(numberTriggered == 3) {
				ActivateSuicideLaneBonus();
			}
		}
	}
	
	public void LifeReset() {
		wasTriggered = false;
		numberTriggered = 0;
		LightBulbScript lbs = lightBulb.GetComponent<LightBulbScript>();
		lbs.TurnOff();		
		ActivateSuicideLaneBonus(false);
	}
	
	void ActivateSuicideLaneBonus(bool turnOn = true) {
		foreach(Transform suicideLaneRolloverLightbulb in suicideLaneRolloverLightbulbs) {
			LightBulbScript lbs = suicideLaneRolloverLightbulb.GetComponent<LightBulbScript>();
			
			if(turnOn == true) {
				lbs.TurnOn ();
				ToastManagerScript.Instance.ShowToast(ToastManagerScript.Instance.texExtinctionEvent);
			}
			else {
				lbs.TurnOff();
			}
		}
	}
	
}
