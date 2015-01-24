using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
		
	public static bool paused=false;
	

	// Update is called once per frame

	void Update () {
		if(Input.GetKeyDown("p") && paused == false) {  
			paused = true;  
			Time.timeScale = 0;
			show ();
			
		}
		else if(Input.GetKeyDown("p") && paused == true) {
			paused = false;
			Time.timeScale = 1;
			hide ();
			
		}  
	}

	void Start()
	{
		hide ();
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
