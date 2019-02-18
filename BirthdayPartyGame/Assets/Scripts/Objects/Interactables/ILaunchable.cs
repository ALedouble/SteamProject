using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILaunchable {

	void GetLaunched(Vector3 _direction, float _force);
	void ShootToBreak();
}
