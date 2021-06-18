using UnityEngine;
using UnityEngine.UI;

public class MenuArrow : MonoBehaviour
{

	[SerializeField] Transform arrowLeft, arrowRight;

	[SerializeField] RectTransform StartButton, HighscoreButton, ExitButton;

	[SerializeField] float arrowSpacing;

	public void MoveToStartButton()
	{
		MoveToButton(StartButton);
	}

	public void MoveToHighscoreButton()
	{
		MoveToButton(HighscoreButton);
	}

	public void MoveToExitButton()
	{
		MoveToButton(ExitButton);
	}

	//Calculates the arrows' positions relative to the button and sets their transform.position to there
	void MoveToButton(RectTransform Rtransform)
	{
		float resMultiple = (float)Screen.width / Screen.currentResolution.width;

		Debug.Log("StartButtonPos: " + StartButton.anchoredPosition);

		Debug.Log("width: " + Screen.currentResolution.width);

		float arrowXL = (Rtransform.anchoredPosition.x - Rtransform.rect.width / 2 - arrowSpacing) * resMultiple;
		float arrowXR = (Rtransform.anchoredPosition.x + Rtransform.rect.width / 2 + arrowSpacing) * resMultiple;
		float arrowY = (Rtransform.anchoredPosition.y - Rtransform.rect.height * 0.6f) * resMultiple;
		Debug.Log("arrowX: " + arrowXL);
		Debug.Log("arrowY: " + arrowY);

		arrowLeft.position = Camera.main.ScreenToWorldPoint(new Vector3(arrowXL, arrowY, 10));
		arrowRight.position = Camera.main.ScreenToWorldPoint(new Vector3(arrowXR, arrowY, 10));
	}

}
