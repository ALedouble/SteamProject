using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectParameters))]
public class Interactable : MonoBehaviour {

	[System.NonSerialized] public ObjectParameters parameters;
	List<InteractableComponent> components = new List<InteractableComponent>();

	[HideInInspector] public Rigidbody body;
	[HideInInspector] public Transform self;
	[HideInInspector] public Collider[] colliders;
	[HideInInspector] public Renderer[] renderers;

	[Space]
	protected Fire fireScript;
	[System.NonSerialized] public GameObject fireParticleSystem;
	protected GameObject myFireParticleSystem;

	[Space]
	protected Water waterScript;
	[System.NonSerialized] public GameObject waterParticleSystem;
	protected ParticleSystem myWaterParticleSystem;

	[Space]
	[System.NonSerialized] public Electricity electricityScript;
	[System.NonSerialized] public GameObject electricityParticleSystem;
	protected ParticleSystem myElectricityParticleSystem;

	[System.NonSerialized]
	public bool canBreak;
	protected bool canActivate = true;
	protected bool activated;

	[System.NonSerialized]
	public bool electrified, burning, wet;
	

	protected virtual void Start()
	{
		Initialize();
	}

	void Initialize()
	{
		if (parameters == null) parameters = GetComponent<ObjectParameters>();
		if (body == null) body = GetComponent<Rigidbody>();
		if (self == null) self = transform;
		if (colliders.Length <= 0) colliders = GetComponents<Collider>();
		if (renderers.Length <= 0) renderers = GetComponents<Renderer>();

		fireParticleSystem = Constants.constants.fireParticle;
		waterParticleSystem = Constants.constants.waterParticle;
		electricityParticleSystem = Constants.constants.electricityParticle;

		if (parameters.breakable) components.Add(gameObject.AddComponent<Breakable>());
		if (parameters.isFire) Burn();

		switch (parameters.material)
		{
			case ObjectMaterial.Paper:
				components.Add(gameObject.AddComponent<Paper>());
				break;
		}

		for (int i = 0; i < components.Count; i++)
		{
			components[i].Initialize(this);
		}

		for (int i = 0; i < parameters.nodes.Length; i++)
		{
			parameters.nodes[i].Initialize(this);
		}
	}

	public void GetGrabbed(Transform _holdPoint)
	{
		self.parent = _holdPoint;
		self.localPosition = parameters.holdPositionOffset;
		self.localRotation = Quaternion.Euler(parameters.holdRotationOffset);
		
		body.constraints = RigidbodyConstraints.FreezeAll;
		gameObject.layer = LayerMask.NameToLayer("Held Objects");
	}

	public void GetDropped()
	{
		self.parent = null;
		body.constraints = RigidbodyConstraints.None;
		gameObject.layer = LayerMask.NameToLayer("Default");

	}

	public virtual void Activate()
	{
		if (!canActivate) return;
	}

	public virtual void Deactivate() { }

	public virtual void Die()
	{
		Destroy(gameObject);
		//body.isKinematic = true;
		//for (int i = 0; i < colliders.Length; i++)
		//{
		//	colliders[i].enabled = false;
		//}
		//for (int i = 0; i < renderers.Length; i++)
		//{
		//	renderers[i].enabled = false;
		//}
		//for (int i = 0; i < components.Count; i++)
		//{
		//	components[i].enabled = false;
		//}
		//for (int i = 0; i < self.childCount; i++)
		//{
		//	self.GetChild(i).gameObject.SetActive(false);
		//}
		//parameters.enabled = false;
		//this.enabled = false;
	}

	#region Entities behavior

	public void Burn()
	{
		print("Start burning");
		burning = true;

		if (fireScript == null)
			fireScript = gameObject.AddComponent<Fire>();
		else
			fireScript.enabled = true;

		if (myFireParticleSystem == null)
		{
			Transform particleTransform;
			//if (parameters.nodes.Length > 0)
			//{
			//	for (int i = 0; i < parameters.nodes.Length; i++)
			//	{
			//		particleTransform = parameters.nodes[i].self;
			//		myFireParticleSystem = Instantiate(fireParticleSystem,
			//									particleTransform.position,
			//									Quaternion.identity, self)
			//									.GetComponent<ParticleSystem>();
			//	}
			//}
			//else
			//{
			particleTransform = self;
			myFireParticleSystem = Instantiate(fireParticleSystem,
											particleTransform.position,
											Quaternion.identity, self)
											/*.GetComponent<ParticleSystem>()*/;
			//}
		}
		else
		{
			ParticleSystem[] parts = myFireParticleSystem.GetComponentsInChildren<ParticleSystem>();
			foreach (var part in parts)
			{
				part.Play();
			}
		}
		//myFireParticleSystem.GetComponent<ParticleSystem>().Play();

		print("My part system is: " + myFireParticleSystem);
		
	}

	public void StopBurning()
	{
		print("Stop burning");
		burning = false;
		fireScript.enabled = false;

		ParticleSystem[] parts = myFireParticleSystem.GetComponentsInChildren<ParticleSystem>();
		foreach(var part in parts)
		{
			part.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		}
		//myFireParticleSystem.GetComponentInChildren<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}

	public void GetWet()
	{
		if (burning)
		{
			StopBurning();
		}
		wet = true;

		if (waterScript == null)
			waterScript = gameObject.AddComponent<Water>();
		else
			waterScript.enabled = true;

		if (myWaterParticleSystem == null)
			myWaterParticleSystem = Instantiate(waterParticleSystem, self.position, Quaternion.identity, self).GetComponent<ParticleSystem>();
		else
			myWaterParticleSystem.Play();
		
	}

	public void GetElectrified(Electricity _creator)
	{
		electrified = true;

		if (electricityScript == null)
		{
			electricityScript = gameObject.AddComponent<Electricity>();
			electricityScript.creator = _creator;
		}
			
		else
			electricityScript.enabled = true;

		if (myElectricityParticleSystem == null)
			myElectricityParticleSystem = Instantiate(electricityParticleSystem, self.position, Quaternion.identity, self).GetComponent<ParticleSystem>();
		else
			myElectricityParticleSystem.Play();
	}

	public void StopElectrified()
	{
		electrified = false;
		electricityScript.enabled = false;
		myElectricityParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}

	#endregion
}
