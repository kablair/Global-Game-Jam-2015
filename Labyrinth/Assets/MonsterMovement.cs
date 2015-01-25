using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	public Vector3 startingPoint;
	int Speed= 10;
	Vector3 wayPoint;
	int Range= 10;
	// Use this for initialization
	void Start () {
		startingPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		startingPoint= transform.position;
	}

	void Update()
	{
		int playerDistance = Vector3.Distance (PlayerScript.position, transform.position);

		//in range of player
		if(playerDistance<10)
		{
			Charge ()
		}
		else
		{
			Wander();
		}
	}
	void Wander()
	{
	
	}
	void Charge()
	{

	}

	void getDeltas()
	[
		 Vector3

	}

	void move(deltaX, deltaY)
	{
		transform.Translate(deltaX, 0, deltaY);
	}

}