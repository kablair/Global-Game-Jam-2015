using UnityEngine;
using System.Collections;


public class ItemPickup : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
	{
		if (isItem (col.gameObject)) {
						audio.PlayOneShot (col.gameObject.audio.clip);
						Inventory.add(col.gameObject);
						//col.gameObject.transform.position=new Vector3(100,0,18);
						//col.gameObject.transform.localScale+= new Vector3(0f,-0.98f,0f);
						//stop item rotation
						Destroy (col.gameObject);
		}
			else if (col.gameObject.name.Equals ("WallModel")) {
			audio.PlayOneShot(this.audio.clip);
		}
	}

	bool isItem(GameObject obj)
	{
		if (obj.tag.Equals("Item")) return true;
		return false;
	}

}