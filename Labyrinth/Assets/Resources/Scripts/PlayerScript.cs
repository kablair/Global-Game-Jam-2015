using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public static Vector3 position;
	public float playerSpeed;
	public Animator animator;
	public static bool attacking;
	public static int attackValue=1;
	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		velocity *= Time.deltaTime * playerSpeed * 100;
		rigidbody.velocity = velocity;
		if(!Paused.paused)
		{
			position=transform.position;
		checkRotation ();
		setSprintKey ();
		checkAttack();
		}
	}

//	public Vector3 getLocation()
//	{
//		return new Vector3(this.GetComponentInParent.lat)
//	}

	void checkAttack()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			audio.PlayOneShot(this.audio.clip);
						attacking = true;

		}

	}

	void checkRotation(){
//		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
//			transform.GetChild(0).forward = new Vector3(-1f, 0f, 0f);
//		   }
//		else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
//			transform.GetChild(0).forward = new Vector3(0f, 0f, 1f);
//		}
//		else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
//			transform.GetChild(0).forward = new Vector3(1f, 0f, 0f);
//		}
//		else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
//			transform.GetChild(0).forward = new Vector3(0f, 0f, -1f);
//		}

		float vtransform;
		float htransform;
			if (Input.GetAxis ("Horizontal") > 0) {
			animator.SetInteger("Direction", 3);			
			htransform=1f;
				} else if (Input.GetAxis ("Horizontal") < 0) {
			animator.SetInteger("Direction", 1);			
			htransform=-1f;
				} else {
						htransform=0;
				}
			if (Input.GetAxis ("Vertical") > 0) {
			animator.SetInteger("Direction", 2);			
			vtransform = 1;
				} else if (Input.GetAxis ("Vertical") < 0) {
			animator.SetInteger("Direction", 0);			
			vtransform = -1;
				} else {
						vtransform=0;
				}

		if(!(htransform==0&&vtransform==0))
		transform.GetChild (0).forward= new Vector3(htransform,0,vtransform);
	}
	

	void setSprintKey(){
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
						playerSpeed = 10.0f;
				} else
						playerSpeed = 5.0f;
	}
}
