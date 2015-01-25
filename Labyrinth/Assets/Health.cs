using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public static int maxHealth=2;
	public static int heath=maxHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void damage(int damage)
	{
		maxHealth -= damage;
		if (maxHealth <= 0) {
			Application.Quit();
		}
	}
}
