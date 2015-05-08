using UnityEngine;
using System.Collections;

public class GoalieScript : MonoBehaviour {

	public BallScript ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("Ball").GetComponent<BallScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if ((Application.platform == RuntimePlatform.Android) ? Input.GetButtonUp ("Mobile PS4_O") : Input.GetButtonUp ("PS4_O")) 
			//StartCoroutine("block");
	}

	IEnumerator block(){
		yield return new WaitForEndOfFrame ();
		float x = 0;
		float y = 0;

		float waitTime = Time.time + (float)ball.time - 1;

		while (Time.time < waitTime) {
			transform.Translate ((transform.position.x < ball.x) ? Time.deltaTime * 10 : -Time.deltaTime * 10, 0, 0);
			yield return new WaitForEndOfFrame ();
		}

		if (ball.time < 1.5) {
			x = Random.Range (-20, 20);
			y = Random.Range (0, 15);
		} else {
			x = (transform.position.x < ball.x) ? ball.x - (transform.localScale.x / 4) - transform.position.x : ball.x + (transform.localScale.x / 4) - transform.position.x;
			y = (transform.position.y < ball.y) ? ball.y - (transform.localScale.y / 4) - transform.position.y : (Mathf.Abs(x) > 5) ? 5 : 0;
		}

		if (y < 0)
			y = 0;

		while (Mathf.Sqrt (Mathf.Pow (x, 2) + Mathf.Pow (y, 2)) > 25) {
			if(x > 0)
				x--;
			else
				x++;

			if(y >= 1)
				y--;

		}

		Debug.Log(x + " " + y);

		GetComponent<Rigidbody> ().velocity = new Vector3 (x, y, 0);
	}
}
