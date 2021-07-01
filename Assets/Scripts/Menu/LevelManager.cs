using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	//Main Menu
	public void ToTitleScreen()
	{
		SceneManager.LoadScene("Title Screen");
	}



	//To Levels
	public void ToTutorialBox()
	{
		SceneManager.LoadScene("Tutorial Box");
	}

	public void ToLongStare()
	{
		SceneManager.LoadScene("Long Stare");
	}

	public void ToBackAlley()
	{
		SceneManager.LoadScene("Back Alley");
	}

	public void ToCarousel()
	{
		SceneManager.LoadScene("Carousel");
	}

	public void ToBean()
	{
		SceneManager.LoadScene("Bean");
	}

	public void ToShift()
	{
		SceneManager.LoadScene("Shift");
	}

	public void ToHourglass()
	{
		SceneManager.LoadScene("Hourglass");
	}




}
