using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {
	public enum Player {P1, P2};

	Rigidbody rigidBody;
	GameObject turret;
	[SerializeField] GameObject bullet, bulletSpawnPoint;
	[SerializeField] [Range(0, 100)]float speed;
	[SerializeField] [Range(0, 180)]float turretLimit;
	[SerializeField] float bulletSpeed;
	public Player p;
	string playerString;

	void Start () {
		playerString = p == Player.P1 ? "P1" : "P2";
		rigidBody = gameObject.GetComponent<Rigidbody> ();
		turret = transform.FindChild ("Gun").gameObject;
	}

	void Update () {
		RoatateTurret ();
		if (Input.GetMouseButtonDown (0)) {
			ShootBullet ();
		}

		float h = Input.GetAxis (playerString + "Horizontal");
		float v = Input.GetAxis (playerString + "Vertical");
		rigidBody.velocity = new Vector3(transform.forward.x * v * speed,
										 0.0f,
										 transform.forward.z * v * speed);
		transform.eulerAngles += Vector3.up * h * StaticClass.GetSide(v);
	}

	void ShootBullet(){
		GameObject tempBullet = Instantiate (bullet, bulletSpawnPoint.transform.position, Quaternion.identity) as GameObject;
		tempBullet.GetComponent<Rigidbody> ().velocity = turret.transform.forward * bulletSpeed;
	}

	void RoatateTurret(){
		float offset = Screen.width / 2;
		float rotation = Input.mousePosition.x - offset;
		rotation /= Screen.width * 0.5f;
		rotation *= turretLimit;
		turret.transform.localEulerAngles = new Vector3 (0, rotation, 0);
	}
}
