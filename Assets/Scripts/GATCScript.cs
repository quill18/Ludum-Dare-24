using UnityEngine;
using System.Collections;

public class GATCScript : MonoBehaviour {
	
	public GameObject dnaObject;
	
	static int triggeredTriggers = 0;
	bool wasTriggered = false;
	
	void OnCollisionEnter() {
		if(!wasTriggered) {
			wasTriggered = true;
			triggeredTriggers++;
			
			if(triggeredTriggers >= 4) {
				SpawnDNA();
			}
		}
	}
	
	void SpawnDNA() {
		GameObject[] spawners = GameObject.FindGameObjectsWithTag("PowerUpSpawnSpot");
		
		int n = spawners.Length;
		
		// Really simple shuffle
		while (n > 1) {
			int k = Random.Range(0, n);
			n--;
			GameObject o = spawners[n];
			spawners[n] = spawners[k];
			spawners[k] = o;
		}
		
		foreach(GameObject spawner in spawners) {
			PowerUpSpawnSpotScript s = spawner.GetComponent<PowerUpSpawnSpotScript>();
			
			if(!s.isOccupied()) {
				s.Spawn(dnaObject);
				return;
			}
		}
		
		Debug.Log ("No unoccupied power up spawn spots.");
		
	}

}
