using UnityEngine;
using System.Collections;

public class attackSystem : person {

	GameObject[] guai;
	Animator guaiAnim;
	guaiAI guaia;
	GameObject rhand;
	// Use this for initialization
	void Start () {
		rhand = GameObject.FindWithTag("rhand");
		hp = 100f;
		if (rhand.transform.childCount == 0) {
			attackDistance = 4f;
			attackPoint = 10f;
		} else if (rhand.transform.FindChild ("sword1")) {
			attackDistance = 7f;
			attackPoint = 30f;
		} else {
			attackDistance = 7f;
			attackPoint = 20f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		guai = GameObject.FindGameObjectsWithTag ("guai");
	}
	public void attackGuai(){
		foreach (GameObject t in guai) {
				guaia = t.GetComponent<guaiAI> ();
				if (Vector3.Distance (transform.position, t.transform.position) < attackDistance &&
					Mathf.Abs(Vector3.Angle(transform.forward,t.transform.position-transform.position)) < 30f) {
					guaiAnim = t.GetComponent<Animator> ();
					guaiAnim.SetTrigger ("takeDamage");
					guaia.hp -= attackPoint;
				}
		}
	}
	public void rollattack(){
		if (rhand.transform.childCount > 1) {
			foreach (GameObject t in guai) {
				guaia = t.GetComponent<guaiAI> ();
				if (Vector3.Distance (transform.position, t.transform.position) < attackDistance &&
				   Mathf.Abs (Vector3.Angle (transform.forward, t.transform.position - transform.position)) < 30f) {
					guaiAnim = t.GetComponent<Animator> ();
					guaiAnim.SetTrigger ("takeDamage");
					guaia.hp -= attackPoint;
				}
			}
		}
	}
}
