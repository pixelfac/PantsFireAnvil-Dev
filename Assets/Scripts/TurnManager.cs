using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public enum GameState { ANVIL_TURN,  ANVILAI_TURN,  PANTS_TURN,  PANTSAI_TURN,  FIRE_TURN,  FIREAI_TURN,  VICTORY,  DEFEAT,  TIE }

public class TurnManager : MonoBehaviour
{
	GameState state;

	[SerializeField] private Vector3 anvilStartLoc, anvilAIStartLoc, pantsStartLoc, pantsAIStartLoc, fireStartLoc, fireAIStartLoc;

	//character elements
	[SerializeField] private GameObject anvil, anvilAI, pants, pantsAI, fire, fireAI;
	//UI elements
	[SerializeField] private GameObject victoryScreen, drawScreen, defeatScreen, turnIndicator;


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

		//turn all endgame UI off
		victoryScreen.gameObject.SetActive(false);
		drawScreen.gameObject.SetActive(false);
		defeatScreen.gameObject.SetActive(false);

		state = GameState.PANTS_TURN;

	}


	public void NextTurn()
	{
		StartCoroutine(Sleep(0.5f));
		checkWinCondition();

		switch (state)
		{
			case GameState.PANTS_TURN: //Player Turn
				state = GameState.PANTSAI_TURN;
				if (pants.GetComponent<Entity>().Get())
				{
					StartCoroutine(pants.GetComponent<PlayerController>().Turn());
					turnIndicator.transform.position = pants.transform.position + Vector3.up;
				}
				//NextTurn();
				break;

			case GameState.PANTSAI_TURN: //Enemy Turn
				state = GameState.FIRE_TURN;
				if (pantsAI.GetComponent<Entity>().Get())
				{
					StartCoroutine(pantsAI.GetComponent<EnemyController>().Turn());
					turnIndicator.transform.position = pantsAI.transform.position + Vector3.up;
				}
				//NextTurn();
				break;

			case GameState.FIRE_TURN: //Player Turn
				state = GameState.FIREAI_TURN;
				if (fire.GetComponent<Entity>().Get())
				{
					StartCoroutine(fire.GetComponent<PlayerController>().Turn());
					turnIndicator.transform.position = fire.transform.position + Vector3.up;
				}
				//NextTurn();
				break;

			case GameState.FIREAI_TURN: //Enemy Turn
				state = GameState.ANVIL_TURN;
				if (fireAI.GetComponent<Entity>().Get())
				{
					StartCoroutine(fireAI.GetComponent<EnemyController>().Turn());
					turnIndicator.transform.position = fireAI.transform.position + Vector3.up;
				}
				//NextTurn();
				break;

			case GameState.ANVIL_TURN: //Player Turn
				state = GameState.ANVILAI_TURN;
				if (anvil.GetComponent<Entity>().Get())
				{
					StartCoroutine(anvil.GetComponent<PlayerController>().Turn());
					turnIndicator.transform.position = anvil.transform.position + Vector3.up;
				}
				//NextTurn();
				break;

			case GameState.ANVILAI_TURN: //Enemy Turn
				state = GameState.PANTS_TURN;
				if (anvilAI.GetComponent<Entity>().Get())
				{
					StartCoroutine(anvilAI.GetComponent<EnemyController>().Turn());
					turnIndicator.transform.position = anvilAI.transform.position + Vector3.up;
				}
				//NextTurn();
				break;

			case GameState.VICTORY:
				victoryScreen.SetActive(true);
				Debug.Log("VICTORY");
				break;

			case GameState.DEFEAT:
				defeatScreen.SetActive(true);
				Debug.Log("DEFEAT");
				break;

			case GameState.TIE:
				drawScreen.SetActive(true);
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
		if (pants.GetComponent<Entity>().Get()) {
			winCount++;
			total++;
		}
		if (pantsAI.GetComponent<Entity>().Get()) {
			loseCount++;
			total++;
		}
		if (fire.GetComponent<Entity>().Get()) {
			winCount++;
			total++;
		}
		if (fireAI.GetComponent<Entity>().Get()) {
			loseCount++;
			total++;
		}
		if (anvil.GetComponent<Entity>().Get()) {
			winCount++;
			total++;
		}
		if (anvilAI.GetComponent<Entity>().Get()) {
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
		Debug.Log("wincount: " + winCount);
		Debug.Log("losecount: " + loseCount);
		Debug.Log("total: " + total);


		//if enough players still remain, NO CHANGE
		if (winCount > 1 && loseCount > 1) return;

		//if only identical chars exist, TIE, otherwise, NO CHANGE
		if (winCount == 1 && loseCount == 1)
		{

			if ((pantsAI.GetComponent<Entity>().Get() && pants.GetComponent<Entity>().Get()) || (fireAI.GetComponent<Entity>().Get() && fire.GetComponent<Entity>().Get()) || (anvilAI.GetComponent<Entity>().Get() && anvil.GetComponent<Entity>().Get()))
			{
				state = GameState.TIE;
				return;
			}
			else return;
		}

	}


}
