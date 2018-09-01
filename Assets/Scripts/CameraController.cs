using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//[SerializeField] private GameObject player;
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offset;       
	private float smoothness = 0.1f;
	void FixedUpdate () 
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothPosition = Vector3.Lerp (transform.position, desiredPosition, smoothness);
		transform.position = smoothPosition;
	}
}