using UnityEngine;
using System.Collections;

public class guaiDeath : MonoBehaviour {
	guaiAI g;
	public AudioClip dead;
	void start(){
		g = GetComponent<guaiAI> ();
		dead = Resources.Load<AudioClip> ("kewuyg"); 
	}
	void death(){
		AudioSource.PlayClipAtPoint (dead,transform.position);
		Destroy (g);
		Destroy (gameObject,2f);
	}
}
