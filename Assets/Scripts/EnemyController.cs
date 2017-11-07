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
	
	void Start(){
		gameOver.text = "";
		player = GameObject.Find("PlayerNinja");
		
	}
	
	void FixedUpdate(){
		checkSight();
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