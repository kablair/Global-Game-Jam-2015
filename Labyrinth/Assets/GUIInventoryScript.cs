using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIInventoryScript : MonoBehaviour {
	string genString;
	string itemString;
	string extraString;
	List<string> stringList;
	// Use this for initialization
	void Start () {

		stringList = new List<string>();
	}
	
//	 Update is called once per frame
	void Update () {
		itemString = "Empty";
		if (Inventory.newPickup) {
			string pickup = ItemPickup.pickupName;
			stringList.Add(pickup);
			Inventory.newPickup =false;
//			extraString = Inventory.get ().name;
				}
		genString = "Empty";
	//	makeButtons ();
	//	makeButtons ();
	}
	void OnGUI () {
			makeButtons ();
	}
	void makeButtons(){// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(310,40,80,20), stringList[0])) {

		}
		
		// Make the second button.
		if(GUI.Button(new Rect(310,70,80,20), stringList[1])) {

		}
		if(GUI.Button(new Rect(310,90,80,20), stringList[2])) {
				
		}

		if(GUI.Button(new Rect(310,110,80,20), stringList[3])) {
				
		}
		if(GUI.Button(new Rect(310,130,80,20), stringList[4])) {
			
		}
		
		if(GUI.Button(new Rect(310,150,80,20), stringList[5])) {
			
		}
	}
	string stringGen(){
		return genString;
	}
	void changeString(){
		genString = ItemPickup.pickupName;
	}
}
