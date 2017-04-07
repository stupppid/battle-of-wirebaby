using UnityEngine;
using System.Collections;

public class animationcontroller : MonoBehaviour {

	Animator anim;
	bool attackb = false;
	bool attackc = false;
	bool ride = false;
	GameObject t;
	movecontroller a;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("idle", true);
		a = GetComponent<movecontroller> ();
		t = GameObject.FindWithTag ("rhand");
	}
	
	// Update is called once per frame
	void Update () {
		//walk
		if (Input.GetKeyDown (KeyCode.W)) {
			anim.SetBool ("walk", true);
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			anim.SetBool ("walk", false);
		}
		//attackA and rangeAttack
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if(t.transform.childCount == 0)
				anim.SetTrigger ("attackA");
			else
				anim.SetTrigger ("weaponAttack");
		}
		//attackB
		if (Input.GetKeyDown (KeyCode.Mouse0)&&attackb ) {
			anim.SetTrigger ("attackB");
		}
		//attackC
		if (Input.GetKeyDown (KeyCode.Mouse0)&&attackc) {
			anim.SetTrigger ("attackC");
		}
		//roll
		if (Input.GetKeyDown (KeyCode.R)&&(!Input.GetKey (KeyCode.W))) {
			ride = !ride;
			anim.SetBool ("ride", ride);
			if (ride) {
				a.movespeed = 10;
			}
			else
				a.movespeed = 6;
		}
	}

	void attackB1()
	{
		attackb = true;
		anim.SetBool ("idle",true);
	}

	void attackB2()
	{
		attackb = false;
	}

	void attackc1()
	{
		attackc = true;

	}

	void attackc2()
	{
		attackc = false;
		anim.SetBool ("idle", true);
	}
}
