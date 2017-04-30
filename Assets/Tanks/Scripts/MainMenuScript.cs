using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class MainMenuScript : MonoBehaviour {
	string progress;
	public string manifest;
	public NetworkManager nManager;
	void Start () {
		manifest = Application.persistentDataPath + manifest;
		GameData.levelName = "/Level.json";
		GameData.p1Pos = new Vector3 (20, 0.1f, 20);
		GameData.p1Rot = new Vector3 (0, 270, 0);
		GameData.p2Pos = new Vector3 (-20, 0.1f, -20);
		GameData.p2Rot = new Vector3 (0, 90, 0);
	}
		
	IEnumerator checkManifest()
	{
		int version = 1;
		if (File.Exists (manifest)) {
			string jsonData = File.ReadAllText (manifest);	
			var fileData = JSON.Parse (jsonData);
			version = fileData ["version"].AsInt;
		} else {
			JSONObject obj = new JSONObject ();
			obj.Add ("version", 1);
			File.WriteAllText (manifest, obj.ToString ());
		}

		WWW www = new WWW("https://dl.dropboxusercontent.com/s/dnddidvelgqdefv/Manifest.json?dl=0");

		while (!www.isDone) {
			yield return null;
		}
			
		string manifestData = Encoding.ASCII.GetString (www.bytes);
		if(manifestData != "")
		{
			var data = JSON.Parse (manifestData);
			if (version <= data ["version"].AsInt) {
				StartCoroutine ("downloadLevels");
			}
		}
	}

	IEnumerator downloadLevels(){
		yield return null;
	}

	public void StartGame(){
		nManager.StartHost ();
	}

	public void JoinGame(){
		nManager.StartClient ();
	}

	public void ChangeLevel (int index){
	
	}

	public void Exit(){
		Application.Quit ();
	}
}
