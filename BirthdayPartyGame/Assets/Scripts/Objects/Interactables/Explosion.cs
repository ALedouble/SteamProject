using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Interactable {

	public float lifetime = .5f;
	float lifeTimer;

	Vector3 targetScale;

	protected override void Start()
	{
		base.Start();
		canBreak = true;
		fireScript.canSpread = true;

	}

	public void InitializeScale(float _scale)
	{
		self = transform;
		targetScale = new Vector3(_scale, _scale, _scale);
	}

	// Update is called once per frame
	void Update () {
		if (!fireScript.canSpread)
		{
			fireScript.canSpread = true;
		}
		if (lifeTimer < lifetime)
		{
			lifeTimer += Time.deltaTime;
			self.localScale = Vector3.Lerp(Vector3.one, targetScale, (lifeTimer / lifetime) * 1.5f);
		}
		else
		{
			Die();
		}

	}

    public override void Burn()
    {
        base.Burn();
        fireScript.canSpread = true;
    }
}
