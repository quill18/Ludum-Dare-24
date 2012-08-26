using UnityEngine;
using System.Collections;

public class PowerUpSpawnSpotScript : MonoBehaviour {
	
	GameObject spawnObject;
	
	public bool isOccupied() {
		if(spawnObject) {
			return true;
		}
		
		return false;
	}
	
	public GameObject Spawn(GameObject go) {
		spawnObject = (GameObject)Instantiate(go, transform.position, transform.rotation);
		return spawnObject;
	}
}
