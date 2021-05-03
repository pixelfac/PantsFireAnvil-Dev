using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_MP : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public bool GamePaused;

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
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
        Time.timeScale = 0F;
        GamePaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1F;
        GamePaused = false;
    }
}
