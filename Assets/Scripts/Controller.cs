using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	//returns tag of the target being targeted by the invoker
	protected string GetTargetTag(string tag)
	{
		switch (tag)
		{
			case "Pants":
				return "Anvil";
			case "Fire":
				return "Pants";
			case "Anvil":
				return "Fire";
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
			case "Pants":
				return "Fire";
			case "Fire":
				return "Anvil";
			case "Anvil":
				return "Pants";
			default:
				Debug.Log("GetSeekerTag(): Tag not found");
				return null;
		}
	}
}
