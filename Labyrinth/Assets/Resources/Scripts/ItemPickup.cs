using UnityEngine;
using System.Collections;


public class ItemPickup : MonoBehaviour
{
	enum Item
	{
		Item1, Rope


	};
	void OnCollisionEnter (Collision col)
	{
		if(isItem (col.gameObject))
			Destroy(col.gameObject);

	}

	bool isItem(GameObject obj)
	{
		foreach (Item  item in ((Item[]) Item.GetValues(typeof(Item))))
		{
		        
			string s= item.ToString();
			if(s.Equals (obj.name))
			{
				return true;
			}
			
		}
		return false;
	}

}