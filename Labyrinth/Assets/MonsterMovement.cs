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
		Charge ();

	}

	void Update()
	{
		// this is called every frame
		// do move code here
		transform.position += transform.TransformDirection(Vector3.forward)*Speed*Time.deltaTime;
		if((transform.position - wayPoint).magnitude < 3)
		{
			// when the distance between us and the target is less than 3
			// create a new way point target
			//Charge();
		}
	}
	void Wander()
	{
		// does nothing except pick a new destination to go to
		float wayPointy = 1;
		float wayPointx = Random.Range (startingPoint.x - Range, startingPoint.x + Range);
		float wayPointz = Random.Range (startingPoint.z - Range, startingPoint.z + Range);

		wayPoint = new Vector3 (wayPointx, wayPointy, wayPointz);
//		if(Vector3.Distance(transform.position,wayPoint)<3|| Vector3.Distance (transform.position,wayPoint)>Range)
//		{
//			Wander ();
//		}

		// don't need to change direction every frame seeing as you walk in a straight line only
		transform.LookAt(wayPoint);
		Debug.Log(wayPoint + " and " + (transform.position - wayPoint).magnitude);
	}
	void Charge()
	{
		wayPoint = PlayerScript.position;
		// don't need to change direction every frame seeing as you walk in a straight line only
		transform.LookAt(wayPoint);
	}

}