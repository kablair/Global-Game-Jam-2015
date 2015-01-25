using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	GameObject target;
//	int moveSpeed=3;
//	int rotationSpeed=3;
//	int range= 10f;
//	int range2= 10f;
//	int stop=0
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectsWithTag("Player")[0]; //target the player
	}

//	void Update()
//	{	int distance = Vector3.Distance(.position, target.position);
//		if (distance<=range2 &&  distance>=range){
//			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
//			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
//		}
//		else if(distance<=range && distance>stop){
//			//move towards the player
//			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
//			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
//			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
//		}
//		else if (distance<=stop) {
//			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
//			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
//		}
//	}


	
}
