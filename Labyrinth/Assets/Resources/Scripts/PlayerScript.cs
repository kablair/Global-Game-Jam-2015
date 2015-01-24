using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.parent.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed);
		transform.parent.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed, Space.World);
	}
}
