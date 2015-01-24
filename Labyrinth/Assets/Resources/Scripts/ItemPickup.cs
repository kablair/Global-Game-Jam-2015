using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Item") {
			Destroy(col.gameObject);
		}
	}
}