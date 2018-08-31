using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

	[SerializeField] private float acceleration;
	[SerializeField] private float maxSpeed;	
	[SerializeField] private GameObject[] nodes;
	private Rigidbody2D playerRigidbody;
	int curr_node=0;

	void Awake()
	{
		playerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		for(int i = 0; i < nodes.Length; i++)
		{
			nodes [i].GetComponentInChildren<Light> ().enabled = false;
			nodes [i].GetComponentInChildren<BoxCollider2D> ().enabled = false;
		}
		nodes [curr_node].GetComponentInChildren<BoxCollider2D>().enabled = true;
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
			nodes [curr_node].GetComponentInChildren<Light> ().enabled = true;
		if (curr_node == nodes.Length-1) {
			GameManager.gameEnded = true;
			return;
		}
		else
			curr_node++;
			nodes [curr_node].GetComponentInChildren<BoxCollider2D>().enabled = true;
	}

}