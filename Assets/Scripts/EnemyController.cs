using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	
	public Text gameOver;
	public float viewDistance;
	public float viewAngle;
	private GameObject player;

	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	private float lastWaypointSwitchTime;
	public float speed = 1.0f;
	
	void Start(){
		gameOver.text = "";
		player = GameObject.Find("PlayerNinja");
		lastWaypointSwitchTime = Time.time;
		
	}
	
	void FixedUpdate(){
		checkSight();

		Vector3 startPosition = waypoints [currentWaypoint].transform.position;
		Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;

		float pathLength = Vector3.Distance (startPosition, endPosition);
		float totalTimeForPath = pathLength / speed;
		float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
		gameObject.transform.position = Vector3.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
 
		if (gameObject.transform.position.Equals(endPosition)) {
			if (currentWaypoint < waypoints.Length - 2) {
				currentWaypoint++;
				lastWaypointSwitchTime = Time.time;
			} else { 
				//Destroy(gameObject);
			}
		}
	}
	
	void checkSight(){
		if (Vector2.Angle(-(transform.up), player.transform.position-transform.position) < viewAngle){
			double distance = Math.Pow(player.transform.position.x - transform.position.x, 2.0)+Math.Pow(player.transform.position.y - transform.position.y,2.0);
			if(distance<viewDistance){
				gameOver.text = "Game Over";
				player.GetComponent<PlayerController>().stopPlayer();
			}
		}
		
	}
}