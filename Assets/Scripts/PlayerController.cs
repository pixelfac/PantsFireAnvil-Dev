using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
	[SerializeField] private GridOverlayBehavior overlay;
	[SerializeField] private GameObject turnIndicator;
	[SerializeField] private AudioSource audioManager;
	private GameObject target, seeker;
	string tag;

	private void Awake()
	{
		tag = gameObject.tag;
		target = GameObject.FindGameObjectWithTag(GetTargetTag(tag));
		seeker = GameObject.FindGameObjectWithTag(GetSeekerTag(tag));
	}


	public IEnumerator PlayerTurn()
	{
		overlay.showPlayerMovementArea(transform.position, gameObject);
		yield return StartCoroutine(overlay.waitForClick(playerPos =>
		{
			transform.position = playerPos;
			turnIndicator.transform.position = playerPos + Vector3.up;
		}));
		yield return new WaitForSeconds(0.5f);
		if (gameObject != null && target != null && transform.position.x == target.transform.position.x && transform.position.y == target.transform.position.y) //if crush
		{
			target.transform.position = new Vector3(0, 20, 0);
			target.GetComponent<Entity>().Set(false);
			audioManager.Play();
		}
		if (transform.position.x == seeker.transform.position.x && transform.position.y == seeker.transform.position.y) //if is crushed
		{
			transform.position = new Vector3(0, 20, 0);
			gameObject.GetComponent<Entity>().Set(false);
			seeker.transform.position = new Vector3(0, 20, 0);
			seeker.GetComponent<Entity>().Set(false);
			audioManager.Play();

		}
	}

}
