using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public struct HighScore
{
	public HighScore(string lvlName = "NoLevel", int score = 0)
	{
		LevelName = lvlName;
		Score = score;
	}

	public string LevelName { get; set; }

	public int Score { get; set; }

	public override string ToString()
	{
		return LevelName + "," + Score;
	}

}


static class HighScoreManager
{

	//Highscores for each Level
    static HighScore[] scores = { 
							new HighScore("Tutorial Box", 0),
							new HighScore("Long Stare", 0),
							new HighScore("Back Alley", 0),
							new HighScore("Carousel", 0),
							new HighScore("Bean", 0),
							new HighScore("Shift", 0),
							new HighScore("Hourglass", 0),
							new HighScore("Plus", 0)
	};

	static string serializationPath = "Assets/GameData/highscores.txt";

    public static bool SetScore(string lvlName, int score)
	{
		Debug.Log("score set");
		for (int i = 0; i < scores.Length; i++)
		{
			if (scores[i].LevelName.Equals(lvlName))
			{
				scores[i].Score = score;
				return true;
			}
		}

		return false;
	}

	public static void SubmitScore(string lvlName, int score)
	{
		Debug.Log("score submitted");
		if (GetScore(lvlName) == 0 || score < GetScore(lvlName))
			SetScore(lvlName, score);
	}

	public static int GetScore(string lvlName)
	{
		for (int i = 0; i < scores.Length; i++)
		{
			if (scores[i].LevelName.Equals(lvlName))
			{
				return scores[i].Score;
			}
		}

		return 0;
	}

	//serializes the scores into file
	public static void SaveScores()
	{
		string[] lines = new string[scores.Length];

		for(int i=0; i < scores.Length; i++)
		{
			lines[i] = scores[i].ToString();
		}

		File.WriteAllLines(serializationPath, lines);

		Debug.Log("Scores Saved");
	}

	//loads scores from file
	public static bool LoadScores()
	{
		if (!File.Exists(serializationPath))
			return false;

		string[] lines = File.ReadAllLines(serializationPath);

		for (int i = 0; i < lines.Length; i++)
		{
			string[] pair = lines[i].Split(',');
			scores[i].LevelName = pair[0];
			scores[i].Score = int.Parse(pair[1]);
			Debug.Log(scores[i].ToString());
		}

		return true;
	}

	//sets all scores to 0
	public static void ResetScores()
	{
		for (int i = 0; i < scores.Length; i++)
			scores[i].Score = 0;
	}
}
