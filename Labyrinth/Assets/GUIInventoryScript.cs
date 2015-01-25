using UnityEngine;
using System.Collections;

public class GUIInventoryScript : MonoBehaviour {
	string genString;
	string itemString;
	// Use this for initialization
	void Start () {
	
	}
	
//	 Update is called once per frame
	void Update () {
		if (Inventory.newPickup) {
			changeString();
			itemString = Inventory.get ().name;
			itemString = "Word";
				}
		genString = Random.value.ToString();
	//	makeButtons ();
	//	makeButtons ();
	}
	void OnGUI () {
		itemString = "No Item";
			makeButtons ();
	}
	void makeButtons(){// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(310,40,80,20), genString)) {


		}
		
		// Make the second button.
		if(GUI.Button(new Rect(310,70,80,20), itemString)) {

		}
	}
	string stringGen(){
		return genString;
	}
	void changeString(){
		genString = ItemPickup.pickupName;
	}
}
