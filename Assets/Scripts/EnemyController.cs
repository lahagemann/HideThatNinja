using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	
	public Text gameOver;
	
	void Start(){
		gameOver.text = "";
		checkSight();
	}
	
	void checkSight(){
		int i = 0;
		if (i>0)
			gameOver.text = "Game Over";
		
	}
	
}