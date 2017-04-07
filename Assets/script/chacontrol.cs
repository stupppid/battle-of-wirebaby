using UnityEngine;
using System.Collections;

public class chacontrol : MonoBehaviour {
	public SkinnedMeshRenderer body;
	public GameObject player;
	public float speed = 180f;
	GameObject n;
	public GameObject t1;
	public Object[] collect = new Object[2];
	public GameObject trail;
	public void onClickPopo () {
		body.sharedMaterial.color = Color.red;
	}

	public void onClickTinkywinky () {
		body.sharedMaterial.color = Color.blue;
	}

	public void onClickLaalaa(){
		body.sharedMaterial.color = Color.yellow;
	}

	public void onClickDispy(){
		body.sharedMaterial.color = Color.green;
	}

	public void onClickSword1(int i){
		if (t1.transform.childCount > 1) {
			Destroy (t1.transform.GetChild (1).gameObject);
		}
		trail.SetActive (true);
		n = GameObject.Instantiate ((GameObject)collect [i]);
		n.transform.SetParent (t1.transform);
		n.transform.localPosition = new Vector3(2.3f,0f,0.3f);
		n.transform.localRotation = Quaternion.Euler(12f,-3f,-87f);
	}

	public void onClickSword2(){
		onClickSword1 (1);
	}

	public void onClickSword3(){
		if (t1.transform.childCount > 1) {
			Destroy (t1.transform.GetChild (1).gameObject);
		}
		trail.SetActive (false);
	}

	public void onClickPlay(){
		DontDestroyOnLoad (player);
		addcomp ();
		Destroy(player.GetComponent<trna> ());
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

	private void addcomp(){
		player.AddComponent<movecontroller> ();
		player.AddComponent<animationcontroller> ();
		player.AddComponent<attackSystem> ();
		player.transform.position = new Vector3 (-180f,0f,180f);
	}
}
