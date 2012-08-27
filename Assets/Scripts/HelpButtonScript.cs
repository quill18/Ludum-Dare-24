using UnityEngine;
using System.Collections;

public class HelpButtonScript : MonoBehaviour {

	public Texture[] helpScreens;
	public Texture arrowIcon;
	
	int helpIndex = -1;
	
	void Start() {
		if(PlayerPrefs.GetInt("HelpWasShown", 0) == 0) {
			helpIndex = 0;
			Time.timeScale = 0;
			PlayerPrefs.SetInt("HelpWasShown", 1);
		}
	}
	
	void OnMouseDown() {
		Debug.Log ("Mouse clicked on help!");
		helpIndex = 0;
		Time.timeScale = 0;
	}
	
	void OnGUI() {
		if(helpIndex >= 0) {
			GUI.DrawTexture(new Rect(Screen.width/2 - 256 - arrowIcon.width/2, Screen.height/2 - 256, 512, 512), helpScreens[helpIndex]);
			
			if( GUI.Button(new Rect(Screen.width/2 + 256 - arrowIcon.width/2, Screen.height/2 - arrowIcon.height / 2, arrowIcon.width, arrowIcon.height), arrowIcon) ) {
				helpIndex++;
				if(helpIndex >= helpScreens.Length) {
					helpIndex = -1;
					Time.timeScale = 1;
				}
			}
		}
	}
}
