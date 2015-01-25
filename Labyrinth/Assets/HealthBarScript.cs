using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
	GameObject m_health_bar_Prefab;
	GameObject m_health_bar_1;
	GameObject m_health_bar_2;
	GameObject m_health_bar_3;

	Sprite img1;
	Sprite img2;
	Sprite img3;
	// Use this for initialization
	void Start () {

		img1= Resources.Load ("Textures/heart1") as Sprite;
		img2= Resources.Load ("Textures/heart2") as Sprite;
		img3= Resources.Load ("Textures/heart3") as Sprite;


		m_health_bar_Prefab= Resources.Load ("Prefabs/heart") as GameObject;
		m_health_bar_1 = GameObject.Instantiate (m_health_bar_Prefab) as GameObject;
		m_health_bar_1.name = "Heart1";
		m_health_bar_2 = GameObject.Instantiate (m_health_bar_Prefab) as GameObject;
		m_health_bar_2.name = "Heart2";
		m_health_bar_3 = GameObject.Instantiate (m_health_bar_Prefab) as GameObject;
		m_health_bar_3.name = "Heart3";

		m_health_bar_1.transform.SetParent (this.transform);
		m_health_bar_1.transform.localPosition=(new Vector3(-400,120,0));

		m_health_bar_2.transform.SetParent (this.transform);
		m_health_bar_2.transform.localPosition=(new Vector3(-350,120,0));

		m_health_bar_3.transform.SetParent (this.transform);
		m_health_bar_3.transform.localPosition=(new Vector3(-300,120,0));

	}
	
	// Update is called once per frame
	void Update () {
		setImage ();
	}

	void setHealth(int health)
	{
		if (health == 6) 
		{

		}

	}

	void setImage()
	{   //Sprite mySprite=img1;
		
		//this.gameObject.GetComponent<SpriteRenderer>().sprite=mySprite;
		UnityEngine.UI.Image theImage = GameObject.Find ("Heart1").GetComponent<UnityEngine.UI.Image>();
		//Sprite newsprite = GameObject.Instantiate (img1) as Sprite;
		theImage.sprite = img3;
	}
}
