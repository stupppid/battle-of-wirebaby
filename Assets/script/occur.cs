using UnityEngine;
using System.Collections;

public class occur : MonoBehaviour {
	public GameObject prefab;
	public GameObject camer;
	float timer = 4f;
	public AudioClip xiu;
	public int headIndex = 1;
	public Texture[] monsterHead;
	public Material head;
	public GameObject[] pos = new GameObject[4];
	string pdhead;
	string elementst = "cubetrigger";
	void update()
	{
		if (timer == 3f) {
			timer -= Time.deltaTime;
		}
		if (timer < 0) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter()
	{
		--timer;
		if (timer == 3f) {
			int bo = 4;
			float scale = 1f;
			for (int i = 1; i < 8; i++) {
				pdhead = elementst + i.ToString ();
				if (name == pdhead) {
					headIndex = i - 1;
					break;
				}
			}
			scale *= Mathf.Pow (1.2f, headIndex);
			prefab.transform.localScale = new Vector3 (scale, scale, scale);
			if (headIndex > 2)
				bo = 8;
			for (int i = 0; i < bo; i++) {
				GameObject s = Instantiate (prefab, transform.position + transform.forward * 30f + 15 * Random.onUnitSphere, Quaternion.identity) as GameObject;
				s.tag = "guai";
				s.AddComponent<guaiAI> ();
				AudioSource.PlayClipAtPoint (xiu, camer.transform.position, 2000);
			}
			head.mainTexture = monsterHead [headIndex];
		}
	}
}
