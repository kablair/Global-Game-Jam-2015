using UnityEngine;
using System.Collections;

public class ItemSort : MonoBehaviour {

	public enum Item{
		apple, feather, shield, staff, ashes, mirror
	};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameObject getPrefab(Item item)
	{

//		if(item.Equals (Item.apple))
//		{
//			GameObject obj = Resources.Load("Prefabs/Apple") as GameObject;
//			return obj;
//		}
//		else if(item.Equals (Item.feather))
//		{
//			GameObject obj = Resources.Load("Prefabs/Feather") as GameObject;
//			return obj;
//		}
		return null;
	}

	public static GameObject getImage(Item item)
	{
//		if(item.Equals (Item.apple))
//		{
//			GameObject obj = Resources.Load("Prefabs/AppleImage") as GameObject;
//			return obj;
//		}
//		else if(item.Equals (Item.feather))
//		{
//			GameObject obj = Resources.Load("Prefabs/FeatherImage") as GameObject;
//			return obj;
//		}
		return null;
	}
}
