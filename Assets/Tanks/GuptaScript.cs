using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GuptaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("downloadFile");
	}

	IEnumerator downloadFile(){
		print ("downloadFile");
		WWW file = new WWW ("https://drive.google.com/uc?export=download&id=0B0VWs2kDBVodTkZvbzlCcWgxVzQ");

		while (!file.isDone) {
			yield return null;
		}

		byte[] bytes = file.bytes;
		string str = Encoding.ASCII.GetString (file.bytes);
		print (str);

	}

	// Update is called once per frame
	void Update () {
		
	}
}
