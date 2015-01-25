using UnityEngine;
using System.Collections;

public class GUIInventoryScript : MonoBehaviour {
	string genString;
	// Use this for initialization
	void Start () {
	
	}
	
//	 Update is called once per frame
	void Update () {
		genString = Random.value.ToString();
	//	makeButtons ();
	//	makeButtons ();
	}
	void OnGUI () {

			makeButtons ();
	}
	void makeButtons(){// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(310,40,80,20), stringGen())) {


		}
		
		// Make the second button.
		if(GUI.Button(new Rect(310,70,80,20), "Level 2")) {

		}
	}
	string stringGen(){
		return genString;
	}
}
