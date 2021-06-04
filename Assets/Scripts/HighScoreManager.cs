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
    static HighScore[] scores = { 
							new HighScore("Tutorial Box", 0),
							new HighScore("Long Stare", 0),
							new HighScore("Back Alley", 0),
							new HighScore("Carousel", 0),
	};

	static string path = "Assets/GameData/highscores.txt";

    public static bool SetScore(string lvlName, int score)
	{
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
		if (score < GetScore(lvlName))
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

		File.WriteAllLines(path, lines);

		Debug.Log("Scores Saved");
	}

	//loads scores from file
	public static bool LoadScores()
	{
		if (!File.Exists(path))
			return false;

		string[] lines = File.ReadAllLines(path);

		for (int i = 0; i < lines.Length; i++)
		{
			string[] pair = lines[i].Split(',');
			scores[i].LevelName = pair[0];
			scores[i].Score = int.Parse(pair[1]);
			Debug.Log(scores[i].ToString());
		}

		return true;
	}
}
