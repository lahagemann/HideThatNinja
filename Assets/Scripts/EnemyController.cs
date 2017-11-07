using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	
	public Text gameOver;
	private GameObject player;
	
	void Start(){
		gameOver.text = "";
		player = GameObject.Find("PlayerNinja");
		
	}
	
	void FixedUpdate(){
		checkSight();
	}
	
	void checkSight(){
		if (Vector2.Angle(-(transform.up), player.transform.position-transform.position) < 2.5){
			gameOver.text = "Game Over";
			player.GetComponent<PlayerController>().stopPlayer();
		}
		
	}
	
}