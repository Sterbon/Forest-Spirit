using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

	[SerializeField] private float acceleration;
	[SerializeField] private float maxSpeed, rotationSpeed;	
	[SerializeField] private GameObject[] nodes;
	[SerializeField] private Image clueImage;
	private Rigidbody2D playerRigidbody;
	int curr_node = 0;

	void Awake()
	{
		clueImage.enabled = false;

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
		float distance = Vector2.Distance(nodes[curr_node].transform.position, transform.position );
		if (distance < 0.5f) {
			clueImage.enabled = true;
		} else {
			clueImage.enabled = false;
		}

		if(movement != Vector2.zero)
		{
			float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, angle), rotationSpeed * Time.deltaTime);
		}

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
		nodes [curr_node].GetComponentInChildren<BoxCollider2D>().enabled = false;
		curr_node++;
		nodes [curr_node].GetComponentInChildren<BoxCollider2D>().enabled = true;
	}

}