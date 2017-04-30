using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class LevelScript : MonoBehaviour {
	public GameObject[] elements;

	int length = 50, width = 50;
	int i, j;
	string level = "10101010101010101010101010101010101010101010101010" +
				   "10101010101010101010101010101010101010101010101010" +
				   "10101010101010101010101010101010101010101010101010";
	
	void Start () {
		
		Vector2 start = new Vector2 ((float)(length - 1) * 0.5f, (float)-(width - 1) * 0.5f);
		Vector2 tempPos = start;
		for (i = 0; i < length; i++) {
			tempPos = start + (Vector2.up * i);
			for (j = 0; j < 3; j++) {
				if (level [i] == '1') {
					GameObject gj = Instantiate (elements [0], new Vector3 (tempPos.x, 1, tempPos.y), Quaternion.identity) as GameObject;
					gj.transform.parent = transform;
				}
				tempPos -= Vector2.right;
			}

		}
	}
}
