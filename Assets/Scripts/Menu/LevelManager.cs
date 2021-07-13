using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	//indeces range from 0-6 corresponding to button numbers 2-8.
	//button 1 is always enabled and so is not considered
	[SerializeField] Button[] buttons;
	[SerializeField] Text[] buttonNums;


	//Main Menu
	public void ToTitleScreen()
	{
		SceneManager.LoadScene("Title Screen");
	}

	public void Start()
	{
		//Disable unavailable levels
		Debug.Log("Disabling levels");

		if (HighScoreManager.GetScore("Tutorial Box") == 0)	//lvl2
			DisableButton(0);
		if (HighScoreManager.GetScore("Long Stare") == 0)	//lvl3
			DisableButton(1);
		if (HighScoreManager.GetScore("Back Alley") == 0)   //lvl4
			DisableButton(2);
		if (HighScoreManager.GetScore("Carousel") == 0)     //lvl5
			DisableButton(3);
		if (HighScoreManager.GetScore("Bean") == 0)         //lvl6
			DisableButton(4);
		if (HighScoreManager.GetScore("Shift") == 0)        //lvl7
			DisableButton(5);
		if (HighScoreManager.GetScore("Hourglass") == 0)    //lvl8
			DisableButton(6);
		

	}

	void DisableButton(int buttonIndex)
	{
		buttons[buttonIndex].interactable = false;
		buttonNums[buttonIndex].color = new Color(0.6f, 0.5450981f, 0.1568628f);
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

	public void ToPlus()
	{
		SceneManager.LoadScene("Plus");
	}





}
