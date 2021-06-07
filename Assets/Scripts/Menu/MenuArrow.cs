using UnityEngine;

public class MenuArrow : MonoBehaviour
{
	public void MoveToStartButton()
	{
		transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
	}

	public void MoveToHowToPlayButton()
	{
		transform.position = new Vector3(transform.position.x, -0.7f, transform.position.z);
	}

	public void MoveToExitButton()
	{
		transform.position = new Vector3(transform.position.x, -2.6f, transform.position.z);
	}

}
