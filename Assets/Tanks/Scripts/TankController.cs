using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TankController : NetworkBehaviour {
	[SerializeField] float acceleration;
	[SerializeField] float speedLimit;
	Rigidbody rigidbody;
	public GameObject bullet;
	GameObject tempBullet;
	public Vector3 bulletOffset, cameraOffset;
	[Range(0, 180)] public float turretRotationLimit;
	GameManager manager;

	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		rigidbody = GetComponent<Rigidbody> ();
	}
		
	void Update () {
		RotateTurret ();
		if (Input.GetMouseButtonDown(0) && GameData.fire) {
			tempBullet = Instantiate (bullet, Vector3.zero, bullet.transform.rotation) as GameObject;
			tempBullet.GetComponent<bulletScript> ().Initialize (bulletOffset, transform.FindChild ("Turret").gameObject);
			rigidbody.AddForce (transform.forward * -200);
			manager.startClock ();
			CmdSpawnBullet ();
		}

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if (v != 0 ) {
			rigidbody.velocity = Helper.LimitSpeed (rigidbody.velocity, speedLimit);
			rigidbody.velocity = new Vector3(v * transform.forward.x * acceleration, 0, v * transform.forward.z * acceleration);
			transform.eulerAngles += Vector3.up * h * Helper.GetSide (v);
		}
	}

	[Command]
	void CmdSpawnBullet(){
			NetworkServer.Spawn (tempBullet);
	}

	void RotateTurret(){
		float x = Input.mousePosition.x;

		x /= Screen.width;
		x = Mathf.Clamp01(x);
		x -= 0.5f;
		x *= turretRotationLimit;
		transform.FindChild ("Turret").eulerAngles = new Vector3 (0, x + 180 + transform.eulerAngles.y, 0);
	}

	public void setCamera(){
		Camera.main.transform.parent = transform;
		Camera.main.transform.localPosition = cameraOffset;
	}
}
