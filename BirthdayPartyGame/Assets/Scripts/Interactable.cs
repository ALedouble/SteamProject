using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectParameters))]
public class Interactable : MonoBehaviour {
	
	public ObjectParameters parameters;
	List<InteractableComponent> components = new List<InteractableComponent>();

	public Rigidbody body;
	public Transform self;

	[Space]
	protected Fire fireScript;
	public GameObject fireParticleSystem;
	protected ParticleSystem myFireParticleSystem;

	[Space]
	protected Water waterScript;
	public GameObject waterParticleSystem;
	protected ParticleSystem myWaterParticleSystem;

	[Space]
	[System.NonSerialized] public Electricity electricityScript;
	public GameObject electricityParticleSystem;
	protected ParticleSystem myElectricityParticleSystem;

	[System.NonSerialized]
	public bool canBreak;
	protected bool canActivate = true;
	protected bool activated;

	[System.NonSerialized]
	public bool electrified, burning, wet;


	// Use this for initialization
	void Awake () {
		if (parameters == null) parameters = GetComponent<ObjectParameters>();
		if (body == null) body = GetComponent<Rigidbody>();
		if (self == null) self = transform;

		if (parameters.breakable) components.Add(gameObject.AddComponent<Breakable>());
		if (parameters.electronic) components.Add(gameObject.AddComponent<Electronic>());

		switch (parameters.material)
		{
			case ObjectMaterial.Paper:
				components.Add(gameObject.AddComponent<Paper>());
				break;
			case ObjectMaterial.Metal:
				break;
		}

		for (int i = 0; i < components.Count; i++)
		{
			components[i].Initialize(this);
		}
	}

	public void GetGrabbed(Transform _holdPoint)
	{
		self.position = _holdPoint.position;
		self.rotation = _holdPoint.rotation;
		self.parent = _holdPoint;
		body.isKinematic = true;
	}

	public void GetDropped()
	{
		self.parent = null;
		body.isKinematic = false;
	}

	public virtual void Activate()
	{
		if (!canActivate) return;
	}

	public virtual void Deactivate() { }

	public virtual void Die()
	{
		gameObject.SetActive(false);
	}

	#region Entities behavior

	public void Burn(GameObject creator)
	{
		burning = true;

		if (fireScript == null)
			fireScript = gameObject.AddComponent<Fire>();
		else
			fireScript.enabled = true;

		if (myFireParticleSystem == null)
			myFireParticleSystem = Instantiate(fireParticleSystem, self.position, Quaternion.identity, self).GetComponent<ParticleSystem>();
		else
			myFireParticleSystem.Play();
		
	}

	public void StopBurning()
	{
		burning = false;
		fireScript.enabled = false;
		myFireParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}

	public void GetWet()
	{
		print("Get wet");
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
		print("Get electrified: " + name);
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

	public void StopElectrify()
	{
		print("Stop electrify: " + name);
		electrified = false;
		electricityScript.enabled = false;
		myElectricityParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}

	#endregion
}
