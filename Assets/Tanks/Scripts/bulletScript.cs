using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class bulletScript : MonoBehaviour {
	[SerializeField] float force;

	public void Initialize(Vector3 offset, GameObject turret){
		transform.parent = turret.transform;
		transform.localPosition = offset;
		transform.parent = null;
		transform.eulerAngles = new Vector3 (0, turret.transform.localEulerAngles.y + 180, transform.eulerAngles.z);
		GetComponent<Rigidbody> ().AddForce (turret.transform.forward * force);
	}
		
	void OnCollisionEnter(Collision pCollision){
		if (pCollision.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().updateScore (!pCollision.gameObject.GetComponent<setup> ().isLocalPlayer);
		}
		Destroy (gameObject);
	}
}
