using UnityEngine;
using System.Collections;

public class guaiAI : person {

	GameObject t;
	public float guaispeed = 5f;
	CharacterController guaiwalk;
	attackSystem playerAttack;
	Animator anim;
	Animator playerAnim;
	Vector3 targetpos;
	public float attackTimer = 1.5f;
	public float wait = 0f;
	public float prepareAttack = 0.5f;
	// Use this for initialization
	void Start () {
		float a = transform.lossyScale.x;
		guaiwalk = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
		t = GameObject.FindWithTag("Player");
		playerAnim = t.GetComponent<Animator> ();
		playerAttack = t.GetComponent<attackSystem> ();
		anim.SetBool ("death", false);
		anim.SetBool ("idle", true);
		anim.SetInteger ("attack", -1);
		attackDistance += a*1.5f - 1.5f;
		attackPoint *= a;
		hp *= a;
	}

	void Update () {
		if (hp <= 0) {
			anim.SetInteger ("attack", -1);
			anim.SetTrigger ("death");
		} else {
			targetpos = t.transform.position;
			targetpos.y = transform.position.y;
			transform.LookAt(targetpos);
			if (wait > 0f) {
				wait -= Time.deltaTime;
				anim.SetInteger ("attack", -1);
				anim.SetBool ("walk", false);
				anim.SetBool ("idle", true);
			}
			if (wait <= 0f) {
				if (Vector3.Distance (transform.position, t.transform.position) > attackDistance) {
					guaiwalk.SimpleMove (transform.forward * guaispeed);
					anim.SetBool ("walk", true);
				} else {
					if (prepareAttack < 0f) {
						anim.SetInteger ("attack", Random.Range (0, 3));
						wait = 1f;
						prepareAttack = 0.5f;
					} else
						prepareAttack -= Time.deltaTime;
					anim.SetBool ("walk", false);
				}
			}
		}
	}

	public void attackp ()
	{
		if (Vector3.Distance (transform.position, t.transform.position) < attackDistance &&
		    Mathf.Abs (Vector3.Angle (transform.forward, t.transform.position - transform.position)) < 30f) {
			playerAnim.SetTrigger ("takeDamage");
			playerAttack.hp -= attackPoint;
		}
	}
}
