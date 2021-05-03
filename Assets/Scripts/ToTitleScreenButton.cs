using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleScreenButton : MonoBehaviour
{
	public void ToTitleScreen()
	{
		SceneManager.LoadScene("Title Screen");
	}
}
