using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	
	public float viewDistance;
	//public float viewAngle;
	private GameObject player;
	private GameObject gameManager;

	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	private float lastWaypointSwitchTime;
	private bool reversePath = false;
	private bool moving = true;
	public float speed = 1.0f;

	private float enemyPause = 2.0f;

	private Vector3 startPosition;
	private Vector3 endPosition;


	void Start(){
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
			if (enemyPause < 0) {
				enemyPause = 2.0f;
				if (!reversePath) {
					if (currentWaypoint < waypoints.Length - 1) {
						currentWaypoint++;
						if (currentWaypoint == waypoints.Length - 1)
							reversePath = true;
						lastWaypointSwitchTime = Time.time;
					}
				} else {
					if (currentWaypoint - 1 >= 0) {
						currentWaypoint--;
						if (currentWaypoint == 0)
							reversePath = false;
						lastWaypointSwitchTime = Time.time;
					}
				}
			} else {
				enemyPause -= Time.deltaTime;
			}
		}

	}

	/**void checkSight(){
		Vector3 movementDirection = (endPosition - startPosition).normalized;

		if (Vector2.Angle(movementDirection, player.transform.position - transform.position) < viewAngle){
			double distance =
				Math.Pow(player.transform.position.x - transform.position.x, 2.0) +
				Math.Pow(player.transform.position.y - transform.position.y, 2.0);
			if(distance < viewDistance){
				if(!player.GetComponent<PlayerController>().transformed) {
					gameManager = GameObject.Find("GameManager");
					gameManager.GetComponent<GameManager>().GameOver();
				} 
			}
		}

	}**/
	
	void checkSight(){
		Vector3 direction = (endPosition - startPosition).normalized;
		Vector2 vec = transform.position;
		vec.x = vec.x + 2;
		vec.y = vec.y + 2;
		
		RaycastHit2D hit = Physics2D.Raycast(vec, direction);
		if(hit != null)
			Debug.Log(hit.collider.tag);
			if(hit.collider.tag == "Player"){
			gameManager = GameObject.Find("GameManager");
			gameManager.GetComponent<GameManager>().GameOver();
			
		}
			
	}
	
	public void StopEnemy(){
		moving=false;
	}
}
