using UnityEngine;
using System.Collections;

public class MuteScript : MonoBehaviour {
	
	bool muted = false;
	
	void OnMouseDown() {
		muted = !muted;
		
		if(muted)
			AudioListener.volume = 0;		
		else 
			AudioListener.volume = 1;
	}
	
}
