//using UnityEngine;
//using System.Collections;
//public class MonsterMovement {
//	public Vector3[] waypoints;
//	public float time;
//	public float wait_time;
//	private float time_till_attack;
//	public bool smooth = false;
//	private float node_radius = 0.5f;
//	private float _t = 0;
//	private Vector3 start, finish;
//	private int index = 0;
//	private float wait_timer = 0;
//	private bool player_detected = false;
//	private float attack_timer = 0;
//	// Use this for initialization
//	void Start ()
//	{
//		SetTargetPosition();
//	}
//	void Update()
//	{
//		// if no player detected, visit the waypoints
//		if (!player_detected)
//		{
//			if (waypoints.Length > 1)
//			{
//				if (_t >= 1.0f)
//				{
//					// this is just a pause before moving to next waypoint
//					if (wait_timer < wait_time)
//						wait_timer += Time.deltaTime;
//					else
//					{
//						SetTargetPosition();
//						wait_timer = 0;
//					}
//				}
//				float time_ratio = smooth ? Mathf.SmoothStep(0.0f, 1.0f, _t) : _t;
//				Transform.position = Vector3.Lerp(start, finish, time_ratio);
//				_t += Time.deltaTime/time;
//			}
//		}
//		else
//		{
//			// can this be done as a coroutine?
//			// I had all sorts of trouble trying to have a simple pause before jump
//			if (attack_timer < time_till_attack)
//				attack_timer += Time.deltaTime;
//			else
//			{
//				// after pausing, jump at the player
//				// repeat this until the player is out of detection zone
//				// to continue back on waypoint path
//			}
//		}
//	}
//	void SetTargetPosition()
//	{
//		if (index > waypoints.Length - 1) index = 0;
//		start = waypoints[index];
//		index++;
//		if (index > waypoints.Length - 1) index = 0;
//		finish = waypoints[index];
//		_t = 0;
//	}
//	void OnTriggerEnter(Collider other)
//	{
//		if (other.tag == "Player")
//			player_detected = true;
//	}
//	void OnTriggerExit(Collider other)
//	{
//		if (other.tag == "Player")
//			player_detected = false;
//	}
//	public void OnDrawGizmos()
//	{
//		if(waypoints == null)
//			return;
//		for(int i=0;i< waypoints.Length;i++) {
//			Vector3 pos = waypoints[i];
//			Gizmos.color = Color.yellow;
//			Gizmos.DrawSphere(pos, node_radius);
//			if(i>0) {
//				Vector3 prev = waypoints[i-1];
//				Gizmos.DrawLine(prev,pos);
//			}
//		}
//	}
//}
