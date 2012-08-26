using UnityEngine;
using System.Collections;

public class DEBUGClickToSpawnScript : MonoBehaviour {
	
	public GameObject ballObject;
	
	void OnMouseDown() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)){
            Vector3 point = hit.point + new Vector3(0, 2f, 0);
			
			Instantiate(ballObject, point, Quaternion.identity);
        }
		
	}
}
