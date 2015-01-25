using UnityEngine;
using System.Collections;


public class ItemPickup : MonoBehaviour
{
	Actionbar actionBar;
	Sprite m_applePrefab;

	void Start(){
		m_applePrefab = Resources.Load ("Textures/ArrowTexture") as Sprite;
	}

	void OnCollisionEnter (Collision col)
	{
		if (isItem (col.gameObject)) {
						audio.PlayOneShot (col.gameObject.audio.clip);
						Inventory.add(col.gameObject);
						//col.gameObject.transform.position=new Vector3(100,0,18);
						//col.gameObject.transform.localScale+= new Vector3(0f,-0.98f,0f);
						//stop item rotation
			reportCollision(col.gameObject.name);
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
	public void reportCollision( string name){
				if (name.Equals("Apple")) {
			//Sprite newSprite = Sprite.Create(Resources.Load("Textures/ArrowTexture"), new Rect(0,0,1,1), new Vector2(0.5f,0.5f),0);
				}
		}
}