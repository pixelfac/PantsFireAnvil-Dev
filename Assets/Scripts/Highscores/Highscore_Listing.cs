using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This class updates the Highscore listing when the user visits the scene

public class Highscore_Listing : MonoBehaviour
{
	[SerializeField] string[] orderedLevelNames;
	[SerializeField] Text[] scoreTextReferences;
	[SerializeField] int listingCharWidth;

	private void Awake()
	{
		for (int i=0; i < orderedLevelNames.Length; i++)
		{
			string scoreAsString = HighScoreManager.GetScore(orderedLevelNames[i]).ToString();
			scoreTextReferences[i].text = scoreAsString.PadLeft(listingCharWidth, '.');
		}
	}
}
