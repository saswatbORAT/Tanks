using UnityEngine;

public static class StaticClass{
	public static int GetSide(float value){
		if(value < 0){
			return -1;
		}else if(value > 0){
			return 1;
		}

		return 0;
	}
}
