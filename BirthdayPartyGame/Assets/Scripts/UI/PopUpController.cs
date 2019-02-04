using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour {

	float lifeTime = 10;
	

	public void Initialize(float _lifetime)
	{
		lifeTime = _lifetime;
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime > 0)
		{
			lifeTime -= Time.deltaTime;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
