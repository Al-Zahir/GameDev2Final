using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	Transform rt;
	public float speed;

	// Use this for initialization
	void Start () {
		rt = this.GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		rt.position += new Vector3 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed, 0);
	}
}
