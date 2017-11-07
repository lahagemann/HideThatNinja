using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Sprite[] spriteArray;
	private SpriteRenderer spriteRenderer;
	private bool canWalk;
	private float timeLeft;
    private Rigidbody2D rb2d;

	void Start()
	{
		canWalk = true;
		timeLeft = 3.0f;
		rb2d = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = spriteArray[0];
    }

	void FixedUpdate()
	{
		if (canWalk)
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
			rb2d.AddForce (movement * speed);
			TransformNinja ();
		}

		if (!canWalk)
		{
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0)
			{
				spriteRenderer.sprite = spriteArray[0];
				timeLeft = 5.0f;
				canWalk = true;
			}
		}
	}

	void TransformNinja()
	{
		if (Input.GetButton ("A"))
		{
			spriteRenderer.sprite = spriteArray[1];
			canWalk = false;
		}

		else if (Input.GetButton ("D"))
		{
			spriteRenderer.sprite = spriteArray[2];
			canWalk = false;
		}

		else if (Input.GetButton ("W"))
		{
			spriteRenderer.sprite = spriteArray[3];
			canWalk = false;
		}
	}
	
	public void stopPlayer(){
		if(canWalk != false)
			canWalk=false;
	}
}
