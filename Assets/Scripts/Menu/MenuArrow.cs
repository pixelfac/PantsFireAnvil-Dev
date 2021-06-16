using UnityEngine;

public class MenuArrow : MonoBehaviour
{

	[SerializeField] Transform arrowLeft, arrowRight;

	public void MoveToStartButton()
	{
		transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
		arrowLeft.position = new Vector3(-5, arrowLeft.position.y, arrowLeft.position.z);
		arrowRight.position = new Vector3(5, arrowRight.position.y, arrowRight.position.z);
	}

	public void MoveToHowToPlayButton()
	{
		transform.position = new Vector3(transform.position.x, -0.7f, transform.position.z);
		arrowLeft.position = new Vector3(-4, arrowLeft.position.y, arrowLeft.position.z);
		arrowRight.position = new Vector3(4, arrowRight.position.y, arrowRight.position.z);
	}

	public void MoveToExitButton()
	{
		transform.position = new Vector3(transform.position.x, -2.6f, transform.position.z);
		arrowLeft.position = new Vector3(-2, arrowLeft.position.y, arrowLeft.position.z);
		arrowRight.position = new Vector3(2, arrowRight.position.y, arrowRight.position.z);
	}

}
