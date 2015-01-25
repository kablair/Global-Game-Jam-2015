using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	public Vector3 startingPoint;
	int Speed= 10;
	int rotationSpeed=10;
	Vector3 wayPoint;
	int Range= 10;
	// Use this for initialization
	void Start () {
		startingPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		startingPoint= transform.position;
	}

	void Update()
	{	//rotate to look at the player 
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerScript.position - transform.position), rotationSpeed*Time.deltaTime);
		transform.position += transform.forward * Speed * Time.deltaTime;
	}


	
}