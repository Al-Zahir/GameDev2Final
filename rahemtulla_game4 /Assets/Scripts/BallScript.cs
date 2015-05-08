using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public Transform target;
	public float time;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void shoot(float power){
		GameObject.Find ("Goalie").GetComponent<GoalieScript>().StartCoroutine("block");
		time = 2 - (0.5f * ((power > 1) ? (power - 1) : 0));
		x = target.position.x + Random.Range (-target.localScale.x, target.localScale.x);
		y = target.position.y + Random.Range (-target.localScale.y, target.localScale.y);
		GetComponent<Rigidbody> ().velocity = new Vector3 (x / time, (y / time) + 0.5f * 9.81f * time, 50 / time);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Goalie") {
			Destroy (GetComponent<Rigidbody>());
			transform.parent = col.gameObject.transform.FindChild("Collider");
			transform.localPosition = Vector3.zero;
		}
	}
}
