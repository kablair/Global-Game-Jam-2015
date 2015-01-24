using UnityEngine;
using System.Collections;

public class Paused : MonoBehaviour {

	public static bool paused=false;

	// Use this for initialization
	void Start () {
		hide ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("p") && paused == false) {  
			paused = true;  
			Time.timeScale = 0;
			show();

		}
		else if(Input.GetKeyDown("p") && paused == true) {
			paused = false;
			Time.timeScale = 1;
			hide ();

		}  
	}

	public void hide()
	{
		GetComponent<Canvas> ().enabled = false;
		
	}
	public void show()
	{
		GetComponent<Canvas> ().enabled = true;
	}

}
