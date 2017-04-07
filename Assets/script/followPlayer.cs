using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
	private GameObject player;
	public float cameraSpeed = 0.9f;
	public float rotateSpeed = 3f;
	private Vector3 targetPosition;
	private Vector3 directionPosition;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		transform.position = player.transform.position + new Vector3(0f,0f,0f);
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		targetPosition = player.transform.position + new Vector3(0f,3f,0f) - 6f * player.transform.forward.normalized ;
		directionPosition = Vector3.Slerp (targetPosition, transform.position, cameraSpeed);
		transform.position = directionPosition;
		transform.LookAt (player.transform.position + new Vector3(0f,3f,0f));
		player.transform.Rotate(player.transform.TransformDirection(Vector3.up),rotateSpeed * Input.GetAxis ("Mouse X"));
	}
}
