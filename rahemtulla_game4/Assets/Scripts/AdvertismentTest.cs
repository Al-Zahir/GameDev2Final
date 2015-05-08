using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertismentTest : MonoBehaviour {
	void Awake() {
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize ("22624");
		} else {
			Debug.Log("Platform not supported");
		}
	}
	
	void OnGUI() {
		if(GUI.Button(new Rect(10, 10, 150, 50), Advertisement.isReady() ? "Show Ad" : "Waiting...")) {
			// Show with default zone, pause engine and print result to debug log
			Advertisement.Show(null, new ShowOptions {
				pause = true,
				resultCallback = result => {
					Debug.Log(result.ToString());
				}
			});
		}
	}
}