using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
	GameObject m_health_bar_Prefab;
	GameObject m_health_bar_1;
	GameObject m_health_bar_2;
	GameObject m_health_bar_3;
	// Use this for initialization
	void Start () {

		m_health_bar_Prefab= Resources.Load ("Prefabs/heart") as GameObject;
		m_health_bar_1 = GameObject.Instantiate (m_health_bar_Prefab) as GameObject;
		m_health_bar_2 = GameObject.Instantiate (m_health_bar_Prefab) as GameObject;
		m_health_bar_3 = GameObject.Instantiate (m_health_bar_Prefab) as GameObject;

		m_health_bar_1.transform.SetParent (this.transform);
		m_health_bar_1.transform.localPosition=(new Vector3(-400,120,0));

		m_health_bar_2.transform.SetParent (this.transform);
		m_health_bar_2.transform.localPosition=(new Vector3(-350,120,0));

		m_health_bar_3.transform.SetParent (this.transform);
		m_health_bar_3.transform.localPosition=(new Vector3(-300,120,0));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
