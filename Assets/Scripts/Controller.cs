using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
	[SerializeField] protected GameObject turnIndicator;
	[SerializeField] protected AudioSource audioManager;
	protected string IDtag;

	//target is the object which this object wants to target
	//seeker is the object which is targeting this object
	protected GameObject target, seeker;

	protected void Awake()
	{
		IDtag = gameObject.tag;
		target = GameObject.FindGameObjectWithTag(GetTargetTag(IDtag));
		seeker = GameObject.FindGameObjectWithTag(GetSeekerTag(IDtag));
	}

	public abstract IEnumerator Turn();

	//returns tag of the target being targeted by the invoker
	protected string GetTargetTag(string tag)
	{
		switch (tag)
		{
			case "PantsAI":
				return "Anvil";
			case "FireAI":
				return "Pants";
			case "AnvilAI":
				return "Fire";
			case "Pants":
				return "AnvilAI";
			case "Fire":
				return "PantsAI";
			case "Anvil":
				return "FireAI";
			default:
				Debug.Log("GetTargetTag(): Tag not found");
				return null;
		}
	}
	
	//returns tag of the seeker seeking the invoker
	protected string GetSeekerTag(string tag)
	{
		switch (tag)
		{
			case "PantsAI":
				return "Fire";
			case "FireAI":
				return "Anvil";
			case "AnvilAI":
				return "Pants";
			case "Pants":
				return "AnvilAI";
			case "Fire":
				return "PantsAI";
			case "Anvil":
				return "FireAI";
			default:
				Debug.Log("GetSeekerTag(): Tag not found");
				return null;
		}
	}
}
