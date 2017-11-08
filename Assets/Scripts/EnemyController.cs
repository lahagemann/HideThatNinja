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
	private bool reversePath = false;
	private bool moving = true;
	public float speed = 1.0f;

	private Vector3 startPosition;
	private Vector3 endPosition;


	void Start(){
		gameOver.text = "";
		player = GameObject.Find("PlayerNinja");
		lastWaypointSwitchTime = Time.time;

	}

	void FixedUpdate(){

		if (!reversePath) {
			startPosition = waypoints [currentWaypoint].transform.position;
			endPosition = waypoints [currentWaypoint + 1].transform.position;
			endPosition.z = gameObject.transform.position.z; // forçar z a ficar = ao z do objeto, senão dá errado
		}
		else {
			startPosition = waypoints [currentWaypoint].transform.position;
			endPosition = waypoints [currentWaypoint - 1].transform.position;
			endPosition.z = gameObject.transform.position.z;
		}

		checkSight();

		float pathLength = Vector2.Distance (startPosition, endPosition);
		float totalTimeForPath = pathLength / speed;
		float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
		if (moving)
			gameObject.transform.position = Vector2.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

		if (gameObject.transform.position.Equals(endPosition)) {
			if (!reversePath) {
				if (currentWaypoint < waypoints.Length - 1) {
					currentWaypoint++;
					if (currentWaypoint == waypoints.Length - 1)
						reversePath = true;
					lastWaypointSwitchTime = Time.time;
				}
			}
			else {
				if(currentWaypoint - 1 >= 0) {
					currentWaypoint--;
					if (currentWaypoint == 0)
						reversePath = false;
					lastWaypointSwitchTime = Time.time;
				}
			}
		}
	}

	void checkSight(){
		Vector3 movementDirection = (endPosition - startPosition).normalized;

		if (Vector2.Angle(movementDirection, player.transform.position - transform.position) < viewAngle){
			double distance =
				Math.Pow(player.transform.position.x - transform.position.x, 2.0) +
				Math.Pow(player.transform.position.y - transform.position.y, 2.0);
			if(distance < viewDistance){
				if(!player.GetComponent<PlayerController>().transformed) {
					gameOver.text = "Game Over";
					player.GetComponent<PlayerController>().stopPlayer();
					moving = false;
				}
			}
		}

	}
}
