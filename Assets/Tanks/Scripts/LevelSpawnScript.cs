using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class LevelSpawnScript : MonoBehaviour {
	public GameObject[] levelItems;
	GameObject temp;
	int i, j;
	Vector2 startPos;

	void Start () {
		OpenLevel ();
	}

	public void OpenLevel(){
		string fileData = File.ReadAllText (Application.persistentDataPath + "/Level.json");
		JSONNode json = JSON.Parse (fileData);
		string levelData = json ["level"] ["design"].Value; 
		int width = json ["level"] ["width"].AsInt, height = json ["level"] ["height"].AsInt;
		startPos = new Vector2 (-((float)width - 1) / 2, ((float)height - 1) / 2);
		for (i = 0; i < width; i++) {
			for (j = 0; j < height; j++) {
				if (levelData[i * width + j] == '1') {
					temp = Instantiate (levelItems [0], new Vector3 (startPos.x + i, 0.5f, startPos.y - j), Quaternion.identity) as GameObject;
					temp.transform.parent = transform;
				}
			}
		}
	}
}
