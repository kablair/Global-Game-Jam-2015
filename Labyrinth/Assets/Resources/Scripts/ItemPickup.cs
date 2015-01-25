using UnityEngine;
using System.Collections;


public class ItemPickup : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
	{
		if (isItem (col.gameObject)) {
						Destroy (col.gameObject);
						audio.PlayOneShot (col.gameObject.audio.clip);
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