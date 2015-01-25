using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		show();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void show(){
				GetComponent<Canvas> ().enabled = true;
		}
}
