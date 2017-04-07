using UnityEngine;
using System.Collections;

public class trna : MonoBehaviour {	
	void Update () {
		transform.Rotate (Vector3.up, 180f * Time.deltaTime);
	}
}
