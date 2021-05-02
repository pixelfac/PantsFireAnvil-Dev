using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public enum GameState { ANVIL_TURN,  ANVILAI_TURN,  PANTS_TURN,  PANTSAI_TURN,  FIRE_TURN,  FIREAI_TURN,  VICTORY,  DEFEAT,  TIE }

public class TurnManager : MonoBehaviour
{
    GameState state;

    public Vector3 anvilStartLoc, anvilAIStartLoc, pantsStartLoc, pantsAIStartLoc, fireStartLoc, fireAIStartLoc;
    //character elements
    public GameObject anvil, anvilAI, pants, pantsAI, fire, fireAI;
    //UI elements
    public GameObject victory_screen, tie_screen, defeat_screen, arrow;


    void Start()
    {
        Time.timeScale = 1f;
        LevelSetup();
        StartCoroutine(IntroAnimations());
        NextTurn();
    }


    IEnumerator IntroAnimations()
    {
        yield return new WaitForSeconds(0.5f);
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
        victory_screen.gameObject.SetActive(false);
        tie_screen.gameObject.SetActive(false);
        defeat_screen.gameObject.SetActive(false);

        state = GameState.PANTS_TURN;

    }


    public void NextTurn()
    {
        IntroAnimations();
        checkWinCondition();

        switch (state)
        {
            case GameState.PANTS_TURN: //Player Turn
                state = GameState.PANTSAI_TURN;
                if (pants.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(pants, anvilAI, fireAI));
                    arrow.transform.position = pants.transform.position + Vector3.up;
                }
                else NextTurn();
                break;

            case GameState.PANTSAI_TURN: //Enemy Turn
                state = GameState.FIRE_TURN;
                if (pantsAI.GetComponent<Entity>().Get())
                {
                    StartCoroutine(EnemyTurn(pantsAI, anvil, fire));
                    arrow.transform.position = pantsAI.transform.position + Vector3.up;
                }
                else NextTurn();
                break;

            case GameState.FIRE_TURN: //Player Turn
                state = GameState.FIREAI_TURN;
                if (fire.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(fire, pantsAI, anvilAI));
                    arrow.transform.position = fire.transform.position + Vector3.up;
                }
                else NextTurn();
                break;

            case GameState.FIREAI_TURN: //Enemy Turn
                state = GameState.ANVIL_TURN;
                if (fireAI.GetComponent<Entity>().Get())
                {
                    StartCoroutine(EnemyTurn(fireAI, pants, anvil));
                    arrow.transform.position = fireAI.transform.position + Vector3.up;
                }
                else NextTurn();
                break;

            case GameState.ANVIL_TURN: //Player Turn
                state = GameState.ANVILAI_TURN;
                if (anvil.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(anvil, fireAI, pantsAI));
                    arrow.transform.position = anvil.transform.position + Vector3.up;
                }
                else NextTurn();
                break;

            case GameState.ANVILAI_TURN: //Enemy Turn
                state = GameState.PANTS_TURN;
                if (anvilAI.GetComponent<Entity>().Get())
                {
                    StartCoroutine(EnemyTurn(anvilAI, fire, pants));
                    arrow.transform.position = anvilAI.transform.position + Vector3.up;
                }
                else NextTurn();
                break;

            case GameState.VICTORY:
                victory_screen.SetActive(true);
                Debug.Log("VICTORY");
                break;

            case GameState.DEFEAT:
                defeat_screen.SetActive(true);
                Debug.Log("DEFEAT");
                break;

            case GameState.TIE:
                tie_screen.SetActive(true);
                Debug.Log("TIE");
                break;
        }
    }

    public IEnumerator PlayerTurn(GameObject seeker, GameObject target, GameObject third)
    {
        GridOverlayBehavior overlay = GetComponent<GridOverlayBehavior>();
        overlay.showPlayerMovementArea(seeker.transform.position, seeker);
        yield return StartCoroutine(overlay.waitForClick(playerPos =>
        {
            seeker.transform.position = playerPos;
            arrow.transform.position = playerPos + Vector3.up;
        }));
        yield return new WaitForSeconds(0.5f);
        if (seeker != null && target != null && seeker.transform.position.x == target.transform.position.x && seeker.transform.position.y == target.transform.position.y) //if crush
        {
            target.transform.position = new Vector3( 0, 20, 0);
            target.GetComponent<Entity>().Set(false);
            GetComponent<AudioSource>().Play();
        }
        if (seeker.transform.position.x == third.transform.position.x && seeker.transform.position.y == third.transform.position.y) //if crush
        {
            seeker.transform.position = new Vector3(0, 20, 0);
            seeker.GetComponent<Entity>().Set(false);
            third.transform.position = new Vector3(0, 20, 0);
            third.GetComponent<Entity>().Set(false);
            GetComponent<AudioSource>().Play();

        }
        NextTurn();
    }



    public IEnumerator EnemyTurn(GameObject seeker,GameObject target, GameObject third)
    {
        yield return new WaitForSeconds(0.5f);
        seeker.GetComponent<Pathfinding2D>().FindPath(seeker, target.transform.position, pants, fire, anvil);
        seeker.transform.position = seeker.GetComponent<Pathfinding2D>().GridOwner.GetComponent<Grid2D>().path[0].worldPosition;
        arrow.transform.position = seeker.GetComponent<Pathfinding2D>().GridOwner.GetComponent<Grid2D>().path[0].worldPosition + Vector3.up;
        yield return new WaitForSeconds(0.5f);
        if (seeker.transform.position.x == target.transform.position.x && seeker.transform.position.y == target.transform.position.y) //if crush
        {
            target.transform.position = new Vector3(0, 20, 0);
            target.GetComponent<Entity>().Set(false);
            seeker.transform.position = new Vector3(0, 20, 0);
            seeker.GetComponent<Entity>().Set(false);
            GetComponent<AudioSource>().Play();

        }
        if (seeker.transform.position.x == third.transform.position.x && seeker.transform.position.y == third.transform.position.y) //if crush
        {
            seeker.transform.position = new Vector3(0, 20, 0);
            seeker.GetComponent<Entity>().Set(false);
            GetComponent<AudioSource>().Play();

        }
        NextTurn();

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
