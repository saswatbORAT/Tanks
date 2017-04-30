using UnityEngine;

public static class Helper {
	public static float GetAngle(float x, float y){
		return Mathf.Atan2(y, x) * 180 / Mathf.PI;
	}

	public static Vector2 GetPoints(float angle) {
		float x = Mathf.Sin ((angle) * Mathf.Deg2Rad);
		float y = Mathf.Cos ((angle) * Mathf.Deg2Rad);

		return new Vector3 (x, y);
	}

	public static Vector3 LimitSpeed(Vector3 velocity, float speedLimit){
		float x = velocity.x, y = velocity.y, z = velocity.z;

		if (speedLimit < Mathf.Abs (x)) {
			x = speedLimit * GetSide (velocity.x);
		}
		if (speedLimit < Mathf.Abs (y)) {
			y = speedLimit * GetSide (velocity.y);
		}
		if (speedLimit < Mathf.Abs (z)) {
			z = speedLimit * GetSide (velocity.z);
		}
			
		return new Vector3 (x, y, z);
	}

	public static int GetSide(float value){
		if (value < 0) {
			return -1;
		} else if (value > 0) {
			return 1;
		}

		return 0;
	}
}
