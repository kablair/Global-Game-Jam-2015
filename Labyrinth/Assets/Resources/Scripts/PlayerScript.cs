using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed);
		transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed, Space.World);
=======
		transform.parent.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed);
		transform.parent.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed, Space.World);
		checkRotation ();
	}
	void checkRotation(){
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.forward = new Vector3(-1f, 0f, 0f);
		   }
		else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
			transform.forward = new Vector3(0f, 0f, 1f);
		}
		else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
			transform.forward = new Vector3(1f, 0f, 0f);
		}
		else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
			transform.forward = new Vector3(0f, 0f, -1f);
		}
>>>>>>> origin/master
	}
}
