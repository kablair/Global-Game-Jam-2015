using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerSpeed = 5.0f;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed);
		transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed, Space.World);
	}
}
