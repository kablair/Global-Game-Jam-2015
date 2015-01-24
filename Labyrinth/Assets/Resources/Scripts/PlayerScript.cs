using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed);
		transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed, Space.World);
		checkRotation ();
	}
	void checkRotation(){
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.GetChild(0).forward = new Vector3(-1f, 0f, 0f);
		   }
		else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
			transform.GetChild(0).forward = new Vector3(0f, 0f, 1f);
		}
		else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
			transform.GetChild(0).forward = new Vector3(1f, 0f, 0f);
		}
		else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
			transform.GetChild(0).forward = new Vector3(0f, 0f, -1f);
		}
	}
}
