using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Interactable
{
	//public ObjectParameters parameters;
	protected Interactable main;
	
	//[HideInInspector] public Transform self;

	//[Space]
	//protected Fire fireScript;
	//public GameObject fireParticleSystem;
	//protected ParticleSystem myFireParticleSystem;

	//[Space]
	//protected Water waterScript;
	//public GameObject waterParticleSystem;
	//protected ParticleSystem myWaterParticleSystem;

	//[Space]
	//[System.NonSerialized] public Electricity electricityScript;
	//public GameObject electricityParticleSystem;
	//protected ParticleSystem myElectricityParticleSystem;

	//[System.NonSerialized]
	//public bool electrified, burning, wet;

	public void Initialize(Interactable _creator)
	{
		main = _creator;

		//if (self == null) self = transform;
		//fireParticleSystem = Constants.constants.fireParticle;
		//waterParticleSystem = Constants.constants.waterParticle;
		//electricityParticleSystem = Constants.constants.electricityParticle;
	}

	public override void Die()
	{
		base.Die();
	}

	//public void Die()
	//{
	//	this.enabled = false;
	//}

	//#region Entities behavior

	//public virtual void Burn()
	//{
	//	burning = true;

	//	if (fireScript == null)
	//		fireScript = gameObject.AddComponent<Fire>();
	//	else
	//		fireScript.enabled = true;

	//	if (myFireParticleSystem == null)
	//	{
	//		Transform particleTransform;
	//		if (parameters.nodes.Length > 0)
	//		{
	//			for (int i = 0; i < parameters.nodes.Length; i++)
	//			{
	//				particleTransform = parameters.nodes[i].self;
	//				myFireParticleSystem = Instantiate(fireParticleSystem,
	//											particleTransform.position,
	//											Quaternion.identity, self)
	//											.GetComponent<ParticleSystem>();
	//			}
	//		}
	//		else
	//		{
	//			particleTransform = self;
	//			myFireParticleSystem = Instantiate(fireParticleSystem,
	//											particleTransform.position,
	//											Quaternion.identity, self)
	//											.GetComponent<ParticleSystem>();
	//		}
	//	}
	//	else
	//		myFireParticleSystem.Play();

	//}

	//public void StopBurning()
	//{
	//	burning = false;
	//	fireScript.enabled = false;
	//	myFireParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	//}

	//public void GetWet()
	//{
	//	if (burning)
	//	{
	//		StopBurning();
	//	}
	//	wet = true;

	//	if (waterScript == null)
	//		waterScript = gameObject.AddComponent<Water>();
	//	else
	//		waterScript.enabled = true;

	//	if (myWaterParticleSystem == null)
	//		myWaterParticleSystem = Instantiate(waterParticleSystem, self.position, Quaternion.identity, self).GetComponent<ParticleSystem>();
	//	else
	//		myWaterParticleSystem.Play();

	//}

	//public void GetElectrified(Electricity _creator)
	//{
	//	electrified = true;

	//	if (electricityScript == null)
	//	{
	//		electricityScript = gameObject.AddComponent<Electricity>();
	//		electricityScript.creator = _creator;
	//	}

	//	else
	//		electricityScript.enabled = true;

	//	if (myElectricityParticleSystem == null)
	//		myElectricityParticleSystem = Instantiate(electricityParticleSystem, self.position, Quaternion.identity, self).GetComponent<ParticleSystem>();
	//	else
	//		myElectricityParticleSystem.Play();
	//}

	//public void StopElectrify()
	//{
	//	electrified = false;
	//	electricityScript.enabled = false;
	//	myElectricityParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	//}

	//#endregion

}
