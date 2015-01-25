using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public static int numberOfSlots=6;
	public static GameObject [] items = new GameObject[numberOfSlots];
	public static int activeSlot=1;
	public static bool newPickup = false;
	static GameObject itemPickup;
	// Use this for initialization
	void Start () {

		for(int n=0; n<numberOfSlots; n++)
		{
			items[n]=null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			drop (activeSlot);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha1)) {
			setActiveSlot(1);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			setActiveSlot(2);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			setActiveSlot(3);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			setActiveSlot(4);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			setActiveSlot(5);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			setActiveSlot (6);
		}
	}

	public static void setActiveSlot(int slotNo)
	{
		activeSlot=slotNo;
	}

	public static void add(GameObject obj)
	{
		int slot = 1;
		newPickup = true;
		while(slot<=6)
		{
			if(items[slot-1]==null)
			{
				Actionbar.assign(obj, slot);
					slot=10;
			}
			slot++;
		}
		itemPickup = obj;
	}

	public static void drop(int slot)
	{
		items [slot-1] = null;
		//create item at player's feet
	}
	public static GameObject get(){
		return itemPickup;
	}

}
