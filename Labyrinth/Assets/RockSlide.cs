using UnityEngine;
using System.Collections;

public class RockSlide : MonoBehaviour {

	GameObject m_rockslide_prefab;
	GameObject m_rockslide1;
	GameObject m_rockslide2;
	GameObject m_rockslide3;

	// Use this for initialization
	void Start () {
	
	//	m_rockslide_prefab = Resources.Load ("Prefabs/Rock");
//		m_rockslide1 = GameObject.Instantiate (m_rockslide_prefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter()
	{
		rockSlide ();
	}

	void rockSlide()
	{

	}
}
