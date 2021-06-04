using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApplication : MonoBehaviour
{
    public void main()
	{
		HighScoreManager.SaveScores();

		Application.Quit();
	}
}
