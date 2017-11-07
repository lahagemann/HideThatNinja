using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	
	public Text gameOver;
	public float viewField;
	private GameObject player;
	
	void Start(){
		gameOver.text = "";
		player = GameObject.Find("PlayerNinja");
		
	}
	
	void FixedUpdate(){
		checkSight();
	}
	
	void checkSight(){
		if (Vector2.Angle(-(transform.up), player.transform.position-transform.position) < 22.5){
			double distance = Math.Pow(player.transform.position.x - transform.position.x, 2.0)+Math.Pow(player.transform.position.y - transform.position.y,2.0);
			if(distance<viewField){
				gameOver.text = "Game Over";
				player.GetComponent<PlayerController>().stopPlayer();
			}
		}
		
	}
	
}