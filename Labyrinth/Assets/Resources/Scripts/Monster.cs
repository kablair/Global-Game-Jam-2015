﻿using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	int health=3;
	int damage=1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			audio.Play();
			Health.damage(damage);
			if (PlayerScript.attacking)
			{
				takeDamage ();
			}
			//col.gameObject.transform.position=new Vector3(100,0,18);
			//col.gameObject.transform.localScale+= new Vector3(0f,-0.98f,0f);
			//stop item rotation
			//Destroy (this.gameObject);
		}


	
	}

	void takeDamage()
	{
		health -= PlayerScript.attackValue;
		if (health <= 0)
		Destroy (this.gameObject);
	}

}
