using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {
	Texture _apple;
	// Use this for initialization
	void Start () {
		_apple = (Texture)Resources.Load("Textures/apple");
		SwitchImage ();

	}
	
	// Update is called once per frame
	void Update () {

	}
	void SwitchImage(){
		transform.guiTexture.texture = _apple;
	}
}
