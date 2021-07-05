using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{

	public override IEnumerator Turn(System.Action calllback)
	{
		overlay.showPlayerMovementArea(transform.position, gameObject);
		yield return StartCoroutine(overlay.waitForClick(playerPos =>
		{
			transform.position = playerPos;
			turnIndicator.position = playerPos + Vector3.up;
		}));
		yield return new WaitForSeconds(0.5f);
		if (gameObject != null && target != null && transform.position.x == target.transform.position.x && transform.position.y == target.transform.position.y) //if crush
		{
			target.transform.position = new Vector3(0, 20, 0);
			target.GetComponent<Controller>().alive = false;
			FindObjectOfType<AudioManager>().Play("Impact");
		}
		if (transform.position.x == seeker.transform.position.x && transform.position.y == seeker.transform.position.y) //if is crushed
		{
			transform.position = new Vector3(0, 20, 0);
			alive = false;
			seeker.transform.position = new Vector3(0, 20, 0);
			seeker.GetComponent<Controller>().alive = false;
			FindObjectOfType<AudioManager>().Play("Impact");

		}
		calllback();
	}

}
