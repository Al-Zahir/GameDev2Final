using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float power;
	public bool shot;
	public bool run;
	public Transform target;

	// Use this for initialization
	void Start () {
		power = 0;
		shot = false;
		run = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Application.platform == RuntimePlatform.Android) ? Input.GetButton ("Mobile PS4_O") : Input.GetButton ("PS4_O") || Input.GetKey(KeyCode.Space)) {
			if (power < 4 && !shot){
				power += Time.deltaTime * 4;
				if(power > 2)
					target.localScale = new Vector3 (power * 8, power * 8, 0.1f);
			}else if(!shot)
				shoot ();
		}
		
		if ((Application.platform == RuntimePlatform.Android) ? Input.GetButtonUp ("Mobile PS4_O") : Input.GetButtonUp ("PS4_O") || Input.GetKeyUp(KeyCode.Space))
			if(!shot)
				shoot ();
		
		if ((Application.platform == RuntimePlatform.Android) ? Input.GetButtonDown ("Mobile PS4_Touch") : Input.GetButtonDown ("PS4_Touch"))
			Application.LoadLevel (Application.loadedLevel);

		if (run) {
			Vector3 ballPos = GameObject.Find ("Ball").transform.position + transform.up * 4 - transform.forward * 10;
			float dis = Vector3.Distance(transform.position, ballPos);
			float time = 0.5f;
			transform.position = Vector3.Lerp (transform.position, ballPos, time / dis);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), time / dis);

			if(transform.position == ballPos){
				run = false;
				GameObject.Find("Ball").GetComponent<BallScript>().shoot(power);
			}
		}
	}

	void shoot(){
		shot = true;
		run = true;
	}
}
