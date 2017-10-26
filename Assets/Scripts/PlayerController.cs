using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Sprite[] spriteArray;
	private SpriteRenderer spriteRenderer;
	private bool canWalk;
   
    private Rigidbody2D rb2d;

	void Start()
	{
		canWalk = true;
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
	}

	void TransformNinja()
	{
		if (Input.anyKey)
		{
			if (Input.GetButton ("Submit"))
			{
				spriteRenderer.sprite = spriteArray[1];
				canWalk = false;
			}
		}
	}
}
