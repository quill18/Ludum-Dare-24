using UnityEngine;
using System.Collections;

public class ToastManagerScript : MonoBehaviour {
	
	public Texture texMultiBall;
	public Texture texExtinctionEvent;
	public Texture texDNACollected;
	public Texture texBreedingGround;
	public Texture texExtraLife;
	public Texture texGeographicIsolation;


	static ToastManagerScript instance = null;
	static public ToastManagerScript Instance {
		get {
			if(instance == null) {
				GameObject go = new GameObject();
				instance = go.AddComponent<ToastManagerScript>();
			}
			
			return instance;
		}
	}
	
	Texture texCurrent;
	float xCurrent;
	float speed = 500f;
	
	
	// Use this for initialization
	void Start () {
		if( instance == null ) 
			instance = this;
		
	}
	
	void Update() {
		xCurrent -= speed * Time.deltaTime;
	}
	
	void OnGUI() {
		if(texCurrent != null) {
			GUI.DrawTexture(new Rect(xCurrent, Screen.height - texCurrent.height, texCurrent.width, texCurrent.height), texCurrent);
		}
	}
	
	public void ShowToast(Texture tex) {
		texCurrent = tex;
		xCurrent = Screen.width;
	}
}
