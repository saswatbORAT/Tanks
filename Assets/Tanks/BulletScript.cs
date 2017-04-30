using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {	
	void OnCollisionEnter(Collision pCol){
		if (pCol.gameObject.tag == "zxzxzzxz") {
		
		}
		Destroy (gameObject);
	}
}
