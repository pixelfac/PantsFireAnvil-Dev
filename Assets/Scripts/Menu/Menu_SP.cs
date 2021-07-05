using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_SP : MonoBehaviour
{

	[SerializeField] Text turnCounter;

	public void ToLevelSelect()
	{
		SceneManager.LoadScene("Level Select");
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void UpdateTurnCounter(int numTurns)
	{
		turnCounter.text = "Turn " + numTurns;
	}
}
