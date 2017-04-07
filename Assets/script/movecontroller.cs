using UnityEngine;
using System.Collections;

public class movecontroller : MonoBehaviour {

	Vector3 movedirection;
	CharacterController m;
	public float movespeed = 6f;
	public float rotateSpeed = 3f;
	public float jumpSpeed = 400f;
	private float jumpTimer = 1f;
	Vector3 forward;
	public float gravity = 200f;
	private float h,v;

	void Start () {
		m = GetComponent<CharacterController> ();
	}

	void Update () {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		forward = transform.TransformDirection (Vector3.right) * h + transform.TransformDirection (Vector3.forward) * v;
		if (Input.GetButtonDown ("Jump")&&m.isGrounded) {
			jumpTimer = 0f;
		}
		if (jumpTimer <= 0.5f) {
			jumpTimer += Time.deltaTime;
			forward.y += jumpSpeed*Time.deltaTime*(0.8f - jumpTimer);
		}
		forward.y -= gravity * Time.deltaTime;
		m.Move (movespeed * forward * Time.deltaTime);
	}
}
