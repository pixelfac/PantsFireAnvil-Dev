using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_SP : MonoBehaviour
{

	public GameObject pauseMenuUI;
	public bool GamePaused;
	[SerializeField] Text turnCounter;

	public void ToLevelSelect()
	{
		SceneManager.LoadScene("Level Select");
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			if (GamePaused == true)
				Resume();
			else if (GamePaused == false)
				Pause();
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		CursorTracker.SetCursorTracker(false);
		Time.timeScale = 0F;
		GamePaused = true;
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		CursorTracker.SetCursorTracker(true);
		Time.timeScale = 1F;
		GamePaused = false;
	}

	public void UpdateTurnCounter(int numTurns)
	{
		turnCounter.text = "Turn " + numTurns;
	}
}
