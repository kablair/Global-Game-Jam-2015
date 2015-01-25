using UnityEngine;
using System.Collections;

public class Actionbar : MonoBehaviour {
	Vector3 m_actionBarStartPosition=new Vector3(0,0,0);

	GameObject m_action_bar_Prefab1;
	GameObject m_action_bar_Prefab2;
	GameObject m_action_bar;




	// Use this for initialization
	void Start () {
		LoadPrefabs ();
		instantiateBar ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadPrefabs()
	{
		m_action_bar_Prefab1= Resources.Load ("Prefabs/item1") as GameObject;
		m_action_bar_Prefab2= Resources.Load ("Prefabs/item2") as GameObject;

	}

	void instantiateBar()
	{
		m_action_bar = GameObject.Instantiate (m_action_bar_Prefab1, m_actionBarStartPosition, new Quaternion ()) as GameObject;
	}
	
	public static void assign(GameObject obj, int slot)
	{
		//obj.transform.position (getSlotLocation (slot));
		//obj.transform.

	}

	public static void getSlotLocation(int SlotNo)
	{
		//return Vector3 (0, 0, 0);
	}

}

