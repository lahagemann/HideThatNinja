using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
	
	public Text gameOver;
	private GameObject player;
	private GameObject[] enemies;
	
	void Start(){
		gameOver.text = "";
	}
	
	public void GameOver(){
		gameOver.text = "Game Over";
		player = GameObject.Find("PlayerNinja");
		player.GetComponent<PlayerController>().stopPlayer();
		
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i=0; i<enemies.Length; i++){
			enemies[i].GetComponent<EnemyController>().StopEnemy();
		}
	}
	
	
	
}