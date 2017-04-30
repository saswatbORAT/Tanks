using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text playerText, opponentText;
	int playerScore = 0, opponentScore = 0;
	public GameObject clock;

	void Start () {
		
	}
		
	public void startClock(){
		GameData.fire = false;
		clock.SetActive (true);
		StartCoroutine ("startClockAnimation");

	}

	IEnumerator startClockAnimation(){
		yield return new WaitForSeconds (2.0f);
		clock.SetActive (false);
		GameData.fire = true;
	}

	public void updateScore(bool isPlayer){
		if (isPlayer) {
			playerScore++;
			playerText.text = "You : " + playerScore.ToString ();
		} else {
			opponentScore++;
			opponentText.text = "Opponent : " + opponentScore.ToString ();
		}
	}
}
