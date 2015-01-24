using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name=="Item1")
			Destroy(col.gameObject);
	
	}
}