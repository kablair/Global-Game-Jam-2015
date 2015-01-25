using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	public int health=4;
	public int damage=2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void takeDamage()
	{
		health -= PlayerScript.attackValue;
		if (health <= 0)
		Destroy (this.gameObject);
	}

}
