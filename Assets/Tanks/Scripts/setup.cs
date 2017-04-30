using UnityEngine.Networking;
using UnityEngine;
using System.Collections;

public class setup : NetworkBehaviour {
	
	void Start() {
		
		if (isLocalPlayer) {
			GetComponent<TankController> ().setCamera ();
			if (GameObject.FindGameObjectsWithTag ("Player").Length == 1) {
				transform.position = GameData.p1Pos;
				transform.eulerAngles = GameData.p1Rot;
			} else {
				transform.position = GameData.p2Pos;
				transform.eulerAngles = GameData.p2Rot;
			}
			StartCoroutine ("checkForOtherPlayer");
		}
	}

	IEnumerator checkForOtherPlayer(){
		//while (GameObject.FindGameObjectsWithTag ("Player").Length != 2) {
			yield return new WaitForSeconds (1.0f);
		//}
		GetComponent<TankController> ().enabled = true;
	}

}
