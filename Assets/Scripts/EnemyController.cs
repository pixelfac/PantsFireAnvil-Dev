﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
	public override IEnumerator Turn()
	{
		yield return new WaitForSeconds(0.5f);
		GetComponent<Pathfinding2D>().FindPath(gameObject, target.transform.position);
		transform.position = GetComponent<Pathfinding2D>().GridOwner.GetComponent<Grid2D>().path[0].worldPosition;
		turnIndicator.transform.position = GetComponent<Pathfinding2D>().GridOwner.GetComponent<Grid2D>().path[0].worldPosition + Vector3.up;
		yield return new WaitForSeconds(0.5f);
		if (transform.position.x == target.transform.position.x && transform.position.y == target.transform.position.y) //if crush
		{
			target.transform.position = new Vector3(0, 20, 0);
			target.GetComponent<Entity>().Set(false);
			transform.position = new Vector3(0, 20, 0);
			GetComponent<Entity>().Set(false);
			audioManager.Play();
		}
		if (transform.position.x == seeker.transform.position.x && transform.position.y == seeker.transform.position.y) //if is crushed
		{
			transform.position = new Vector3(0, 20, 0);
			GetComponent<Entity>().Set(false);
			audioManager.Play();
		}
	}
}