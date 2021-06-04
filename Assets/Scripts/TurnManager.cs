using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public enum GameState { ANVIL_TURN, ANVILAI_TURN, PANTS_TURN, PANTSAI_TURN, FIRE_TURN, FIREAI_TURN, VICTORY, DEFEAT, TIE }

public class TurnManager : MonoBehaviour
{
	GameState state;

	Vector3 anvilStartLoc, anvilAIStartLoc, pantsStartLoc, pantsAIStartLoc, fireStartLoc, fireAIStartLoc;

	//character elements
	GameObject anvil, anvilAI, pants, pantsAI, fire, fireAI;
	//UI elements
	GameObject victoryScreen, drawScreen, defeatScreen, turnIndicator;
	Menu_SP ui;

	int numTurns = 0;

	void Awake()
	{
		//assign member variables
		pants = GameObject.Find("Pants");
		pantsAI = GameObject.Find("PantsAI");
		anvil = GameObject.Find("Anvil");
		anvilAI = GameObject.Find("AnvilAI");
		fire = GameObject.Find("Fire");
		fireAI = GameObject.Find("FireAI");

		pantsStartLoc = RoundVector3(pants.transform.position);
		pantsAIStartLoc = RoundVector3(pantsAI.transform.position);
		fireStartLoc = RoundVector3(fire.transform.position);
		fireAIStartLoc = RoundVector3(fireAI.transform.position);
		anvilStartLoc = RoundVector3(anvil.transform.position);
		anvilAIStartLoc = RoundVector3(anvilAI.transform.position);

		victoryScreen = GameObject.Find("Canvas/Menu_SP/VictoryScreen");
		defeatScreen = GameObject.Find("Canvas/Menu_SP/DefeatScreen");
		drawScreen = GameObject.Find("Canvas/Menu_SP/DrawScreen");
		ui = GameObject.Find("Canvas/Menu_SP").GetComponent<Menu_SP>();

		turnIndicator = GameObject.Find("TurnIndicator");
	}

	void Start()
	{
		Time.timeScale = 1f;
		LevelSetup();
		StartCoroutine(Sleep(0.5f));
		NextTurn();
	}


	IEnumerator Sleep(float time)
	{
		yield return new WaitForSeconds(time);
	}


	//instantiates player and enemy and assigns Transforms for pathfinding
	void LevelSetup()
	{
		//sets all entities to starting locations
		anvil.transform.position = anvilStartLoc;
		anvilAI.transform.position = anvilAIStartLoc;
		pants.transform.position = pantsStartLoc;
		pantsAI.transform.position = pantsAIStartLoc;
		fire.transform.position = fireStartLoc;
		fireAI.transform.position = fireAIStartLoc;

		turnIndicator.transform.position = pantsStartLoc + Vector3.up;

		//turn all endgame UI off
		victoryScreen.gameObject.SetActive(false);
		drawScreen.gameObject.SetActive(false);
		defeatScreen.gameObject.SetActive(false);

		state = GameState.PANTS_TURN;

	}


	public void NextTurn()
	{
		StartCoroutine(Sleep(0.5f));
		UpdateTurnCounter();
		checkWinCondition();

		switch (state)
		{
			case GameState.PANTS_TURN: //Player Turn
				state = GameState.PANTSAI_TURN;
				if (pants.GetComponent<Controller>().alive)
				{
					StartCoroutine(pants.GetComponent<PlayerController>().Turn(NextTurn));
					turnIndicator.transform.position = pants.transform.position + Vector3.up;
				}
				else NextTurn();
				break;

			case GameState.PANTSAI_TURN: //Enemy Turn
				state = GameState.FIRE_TURN;
				if (pantsAI.GetComponent<Controller>().alive)
				{
					StartCoroutine(pantsAI.GetComponent<EnemyController>().Turn(NextTurn));
					turnIndicator.transform.position = pantsAI.transform.position + Vector3.up;
				}
				else NextTurn();
				break;

			case GameState.FIRE_TURN: //Player Turn
				state = GameState.FIREAI_TURN;
				if (fire.GetComponent<Controller>().alive)
				{
					StartCoroutine(fire.GetComponent<PlayerController>().Turn(NextTurn));
					turnIndicator.transform.position = fire.transform.position + Vector3.up;
				}
				else NextTurn();
				break;

			case GameState.FIREAI_TURN: //Enemy Turn
				state = GameState.ANVIL_TURN;
				if (fireAI.GetComponent<Controller>().alive)
				{
					StartCoroutine(fireAI.GetComponent<EnemyController>().Turn(NextTurn));
					turnIndicator.transform.position = fireAI.transform.position + Vector3.up;
				}
				else NextTurn();
				break;

			case GameState.ANVIL_TURN: //Player Turn
				state = GameState.ANVILAI_TURN;
				if (anvil.GetComponent<Controller>().alive)
				{
					StartCoroutine(anvil.GetComponent<PlayerController>().Turn(NextTurn));
					turnIndicator.transform.position = anvil.transform.position + Vector3.up;
				}
				else NextTurn();
				break;

			case GameState.ANVILAI_TURN: //Enemy Turn
				state = GameState.PANTS_TURN;
				if (anvilAI.GetComponent<Controller>().alive)
				{
					StartCoroutine(anvilAI.GetComponent<EnemyController>().Turn(NextTurn)); ;
					turnIndicator.transform.position = anvilAI.transform.position + Vector3.up;
				}
				else NextTurn();
				break;

			case GameState.VICTORY:
				victoryScreen.SetActive(true);
				HighScoreManager.SubmitScore(SceneManager.GetActiveScene().name, numTurns);
				Debug.Log("VICTORY");
				break;

			case GameState.DEFEAT:
				defeatScreen.SetActive(true);
				HighScoreManager.SubmitScore(SceneManager.GetActiveScene().name, numTurns);
				Debug.Log("DEFEAT");
				break;

			case GameState.TIE:
				drawScreen.SetActive(true);
				HighScoreManager.SubmitScore(SceneManager.GetActiveScene().name, numTurns);
				Debug.Log("TIE");
				break;
		}
	}


	public void checkWinCondition()
	{
		//called at the end of every turn method
		//checks to see if the game has been won, lost, or tied
		int winCount = 0;
		int loseCount = 0;
		int total = 0;
		if (pants.GetComponent<Controller>().alive)
		{
			winCount++;
			total++;
		}
		if (pantsAI.GetComponent<Controller>().alive)
		{
			loseCount++;
			total++;
		}
		if (fire.GetComponent<Controller>().alive)
		{
			winCount++;
			total++;
		}
		if (fireAI.GetComponent<Controller>().alive)
		{
			loseCount++;
			total++;
		}
		if (anvil.GetComponent<Controller>().alive)
		{
			winCount++;
			total++;
		}
		if (anvilAI.GetComponent<Controller>().alive)
		{
			loseCount++;
			total++;
		}

		//if all player chars are destroyed, DEFEAT
		if (winCount == 0)
		{
			state = GameState.DEFEAT;
			return;
		}

		//if all enemy chars are destroyed, VICTORY
		if (loseCount == 0 && winCount != 0)
		{
			state = GameState.VICTORY;
			return;
		}

		//if enough players still remain, NO CHANGE
		if (winCount > 1 && loseCount > 1) return;

		//if only identical chars exist, TIE, otherwise, NO CHANGE
		if (winCount == 1 && loseCount == 1)
		{

			if ((pantsAI.GetComponent<Controller>().alive && pants.GetComponent<Controller>().alive) || (fireAI.GetComponent<Controller>().alive && fire.GetComponent<Controller>().alive) || (anvilAI.GetComponent<Controller>().alive && anvil.GetComponent<Controller>().alive))
			{
				state = GameState.TIE;
				return;
			}
			else return;
		}

	}

	Vector3 RoundVector3(Vector3 vector)
	{
		return new Vector3(
			Mathf.Round(vector.x),
			Mathf.Round(vector.y),
			Mathf.Round(vector.z));
	}

	void UpdateTurnCounter()
	{
		if (state == GameState.PANTS_TURN)
		{
			numTurns++;
			ui.UpdateTurnCounter(numTurns);
		}
	}
}
