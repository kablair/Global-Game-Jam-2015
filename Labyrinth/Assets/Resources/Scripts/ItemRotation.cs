using UnityEngine;
using System.Collections;

public class ItemRotation : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		setRotation ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
	}
	void setRotation(){
		transform.Rotate(45, 45, 45);
	}
}
