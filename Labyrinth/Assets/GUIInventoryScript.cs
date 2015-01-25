using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIInventoryScript : MonoBehaviour {
	string genString;
	string itemString;
	string extraString;
	GameObject player;
	Vector3 spawnPoint;
	List<string> stringList;
	int index =0;
	LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager>();
		stringList = new List<string>();
		for (int i =0; i<6; i++) {
			stringList.Add("");}
	}
	
//	 Update is called once per frame
	void Update () {
		if (Inventory.newPickup) {
			string pickup = ItemPickup.pickupName;
			stringList[index] = pickup;
			index++;
			if(index>=6){
				index=0;
					if(!stringList[0].Equals(""))
				   {
					ButtonAction(6);
					}
				}
			Inventory.newPickup =false;
				}

	}
	void OnGUI () {
			makeButtons ();
	}
	void ButtonAction(int index){
		levelManager.createItemAtPlayer(stringList[index]);
		stringList[index]="";}

	void makeButtons(){// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(310,40,80,20), stringList[0])) {
			ButtonAction(0);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(310,70,80,20), stringList[1])) {
			ButtonAction(1);
		}
		if(GUI.Button(new Rect(310,100,80,20), stringList[2])) {
			ButtonAction(2);
		}

		if(GUI.Button(new Rect(310,130,80,20), stringList[3])) {
			ButtonAction(3);
		}
		if(GUI.Button(new Rect(310,160,80,20), stringList[4])) {
			ButtonAction(4);
		}
		
		if(GUI.Button(new Rect(310,190,80,20), stringList[5])) {
			ButtonAction(5);
		}
	}
}
