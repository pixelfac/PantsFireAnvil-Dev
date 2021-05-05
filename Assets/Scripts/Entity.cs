using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public bool Alive = true;

	public void SetAlive(bool param)
	{
		Alive = param;
	}

	public bool IsAlive()
	{
		return Alive;
	}
}
