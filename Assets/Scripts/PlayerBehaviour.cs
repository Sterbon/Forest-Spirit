using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

	[SerializeField] private float acceleration;
	[SerializeField] private float maxSpeed;	

	private Rigidbody2D playerRigidbody;       

	void Start()
	{
		playerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (horizontalMovement, verticalMovement);

		playerRigidbody.AddForce(movement * acceleration);
		playerRigidbody.velocity = Vector2.ClampMagnitude(playerRigidbody.velocity, maxSpeed);

	}

	void OnTriggerEnter2D(Collider2D node)
	{
		
	}
}

