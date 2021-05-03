using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public enum GameStateMP { ANVIL_BLUE,  ANVIL_RED,  PANTS_BLUE,  PANTS_RED,  FIRE_BLUE,  FIRE_RED,  BluVICTORY,  RedVICTORY,  TIE }

public class TurnManagerMP : MonoBehaviour
{
    GameStateMP state;

    public Vector3 anvilBluStartLoc, anvilRedStartLoc, pantsBluStartLoc, pantsRedStartLoc, fireBluStartLoc, fireRedStartLoc;
    //character elements
    public GameObject anvilBlu, anvilRed, pantsBlu, pantsRed, fireBlu, fireRed;
    //UI elements
    public GameObject blu_victory_screen, tie_screen, red_victory_screen, arrow;
    public Text red_turn, blu_turn;


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
        anvilBlu.transform.position = anvilBluStartLoc;
        anvilRed.transform.position = anvilRedStartLoc;
        pantsBlu.transform.position = pantsBluStartLoc;
        pantsRed.transform.position = pantsRedStartLoc;
        fireBlu.transform.position = fireBluStartLoc;
        fireRed.transform.position = fireRedStartLoc;

        //turn all endgame UI off
        blu_victory_screen.gameObject.SetActive(false);
        tie_screen.gameObject.SetActive(false);
        red_victory_screen.gameObject.SetActive(false);

        state = GameStateMP.PANTS_BLUE;

    }


    public void NextTurn()
    {
        IntroAnimations();
        checkWinCondition();

        switch (state)
        {
            case GameStateMP.PANTS_BLUE: //Blu Turn
                state = GameStateMP.PANTS_RED;
                if (pantsBlu.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(pantsBlu, anvilRed, fireRed));
                    arrow.transform.position = pantsBlu.transform.position + Vector3.up;
                    BluTurn();
                }
                else NextTurn();
                break;

            case GameStateMP.PANTS_RED: //Red Turn
                state = GameStateMP.FIRE_BLUE;
                if (pantsRed.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(pantsRed, anvilBlu, fireBlu));
                    arrow.transform.position = pantsRed.transform.position + Vector3.up;
                    RedTurn();
                }
                else NextTurn();
                break;

            case GameStateMP.FIRE_BLUE:  //Blu Turn
                state = GameStateMP.FIRE_RED;
                if (fireBlu.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(fireBlu, pantsRed, anvilRed));
                    arrow.transform.position = fireBlu.transform.position + Vector3.up;
                    BluTurn();
                }
                else NextTurn();
                break;

            case GameStateMP.FIRE_RED: //Red Turn
                state = GameStateMP.ANVIL_BLUE;
                if (fireRed.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(fireRed, pantsBlu, anvilBlu));
                    arrow.transform.position = fireRed.transform.position + Vector3.up;
                    RedTurn();
                }
                else NextTurn();
                break;

            case GameStateMP.ANVIL_BLUE:  //Blu Turn
                state = GameStateMP.ANVIL_RED;
                if (anvilBlu.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(anvilBlu, fireRed, pantsRed));
                    arrow.transform.position = anvilBlu.transform.position + Vector3.up;
                    BluTurn();
                }
                else NextTurn();
                break;

            case GameStateMP.ANVIL_RED:  //Red Turn
                state = GameStateMP.PANTS_BLUE;
                if (anvilRed.GetComponent<Entity>().Get())
                {
                    StartCoroutine(PlayerTurn(anvilRed, fireBlu, pantsBlu));
                    arrow.transform.position = anvilRed.transform.position + Vector3.up;
                    RedTurn();
                }
                else NextTurn();
                break;

            case GameStateMP.BluVICTORY:
                blu_victory_screen.SetActive(true);
                Debug.Log("BLU VICTORY");
                break;

            case GameStateMP.RedVICTORY:
                red_victory_screen.SetActive(true);
                Debug.Log("RED VICTORY");
                break;

            case GameStateMP.TIE:
                tie_screen.SetActive(true);
                Debug.Log("TIE");
                break;
        }
    }


        public IEnumerator PlayerTurn(GameObject seeker, GameObject target, GameObject third)
        {
            GridOverlayBehaviorMP overlay = GetComponent<GridOverlayBehaviorMP>();
            overlay.showPlayerMovementArea(seeker.transform.position, seeker);
            yield return StartCoroutine(overlay.waitForClick(playerPos =>
            {
                seeker.transform.position = playerPos;
                arrow.transform.position = playerPos + Vector3.up;
            }));
            yield return new WaitForSeconds(0.5f);
            if (seeker != null && target != null && seeker.transform.position.x == target.transform.position.x && seeker.transform.position.y == target.transform.position.y) //if crush
            {
                target.transform.position = new Vector3(0, 20, 0);
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
    



    public void checkWinCondition()
    {
        //called at the end of every turn method
        //checks to see if the game has been won, lost, or tied
        int bluCount = 0;
        int redCount = 0;
        int total = 0;
        if (pantsBlu.GetComponent<Entity>().Get()) {
            bluCount++;
            total++;
        }
        if (pantsRed.GetComponent<Entity>().Get()) {
            redCount++;
            total++;
        }
        if (fireBlu.GetComponent<Entity>().Get()) {
            bluCount++;
            total++;
        }
        if (fireRed.GetComponent<Entity>().Get()) {
            redCount++;
            total++;
        }
        if (anvilBlu.GetComponent<Entity>().Get()) {
            bluCount++;
            total++;
        }
        if (anvilRed.GetComponent<Entity>().Get()) {
            redCount++;
            total++;
        }

        //if all player chars are destroyed, DEFEAT
        if (bluCount == 0)
        {
            state = GameStateMP.RedVICTORY;
            return;
        }

        //if all enemy chars are destroyed, VICTORY
        if (redCount == 0 && bluCount != 0)
        {
            state = GameStateMP.BluVICTORY;
            return;
        }
        Debug.Log("bluCount: " + bluCount);
        Debug.Log("redCount: " + redCount);
        Debug.Log("total: " + total);


        //if enough players still remain, NO CHANGE
        if (bluCount > 1 && redCount > 1) return;

        //if only identical chars exist, TIE, otherwise, NO CHANGE
        if (bluCount == 1 && redCount == 1)
        {

            if ((pantsRed.GetComponent<Entity>().Get() && pantsBlu.GetComponent<Entity>().Get()) || (fireRed.GetComponent<Entity>().Get() && fireBlu.GetComponent<Entity>().Get()) || (anvilRed.GetComponent<Entity>().Get() && anvilBlu.GetComponent<Entity>().Get()))
            {
                state = GameStateMP.TIE;
                return;
            }
            else return;
        }

    }

    public void BluTurn()
    {
        blu_turn.color = new Color(blu_turn.color.r,blu_turn.color.g,blu_turn.color.b, 1f);
        red_turn.color = new Color(red_turn.color.r, red_turn.color.g, red_turn.color.b, 0.5f);
    }

    public void RedTurn()
    {
        blu_turn.color = new Color(blu_turn.color.r, blu_turn.color.g, blu_turn.color.b, 0.5f);
        red_turn.color = new Color(red_turn.color.r, red_turn.color.g, red_turn.color.b, 1f);
    }
}
