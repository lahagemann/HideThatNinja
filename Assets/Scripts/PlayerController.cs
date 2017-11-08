using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public bool transformed;
	public Sprite[] spriteArray;
	private SpriteRenderer spriteRenderer;
	private bool canWalk;
	private float timeLeft;
  private Rigidbody2D rb2d;

	void Start()
	{
		canWalk = true;
		transformed = false;
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

		if (transformed)
		{
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0)
			{
				spriteRenderer.sprite = spriteArray[0];
				timeLeft = 5.0f;
				canWalk = true;
				transformed = false;
				gameObject.GetComponent<Collider2D>().enabled = true;
			}
		}
	}

	void TransformNinja()
	{
		if (Input.GetButton ("A"))
		{
			spriteRenderer.sprite = spriteArray[1];
			canWalk = false;
			transformed = true;
			gameObject.GetComponent<Collider2D>().enabled = false;

			Vector3 scale = new Vector3 (0.2f, 0.2f, 1f);
			transform.localScale = scale;
		}

		else if (Input.GetButton ("D"))
		{
			spriteRenderer.sprite = spriteArray[2];
			canWalk = false;
			transformed = true;
			gameObject.GetComponent<Collider2D>().enabled = false;

			Vector3 scale = new Vector3 (0.4f, 0.4f, 1f);
			transform.localScale = scale;
		}

		else if (Input.GetButton ("W"))
		{
			spriteRenderer.sprite = spriteArray[3];
			canWalk = false;
			transformed = true;
			gameObject.GetComponent<Collider2D>().enabled = false;

			Vector3 scale = new Vector3 (0.4f, 0.4f, 1f);
			transform.localScale = scale;
		}
	}

	public void stopPlayer(){
		if(canWalk != false)
			canWalk=false;
	}
}
