using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridOverlayBehavior : MonoBehaviour
{

	[SerializeField] private Tile greyOverlay, greenOverlay, redOverlay;
	Tilemap overlayTilemap, obstacleTilemap;
	GameObject pants, fire, anvil, pantsAI, fireAI, anvilAI;
	Vector3Int[] positions;
	Vector3 pos;

	private void Awake()
	{
		//assign member variables
		overlayTilemap = GameObject.Find("OverlayMap").GetComponent<Tilemap>();
		obstacleTilemap = GameObject.Find("ObstacleMap").GetComponent<Tilemap>();

		pants = GameObject.Find("Pants");
		pantsAI = GameObject.Find("PantsAI");
		anvil = GameObject.Find("Anvil");
		anvilAI = GameObject.Find("AnvilAI");
		fire = GameObject.Find("Fire");
		fireAI = GameObject.Find("FireAI");
	}


	//overlays in green the tiles that the character can move to
	//and adds that world position to an array for later checking in method:waitForClick()
	public void showPlayerMovementArea(Vector3 position, GameObject obj)
	{
		pos = position;
		//set every value to <1,1,1> which serves as a null value since no Vector3 generated
		//in this 2D game will have a z component and Vector3 is non-nullable.
		positions = new Vector3Int[] { Vector3Int.one, Vector3Int.one, Vector3Int.one, Vector3Int.one};


		//if object making the check is pants, avoid allies + avoid pantsAI
		if (obj.CompareTag("Pants"))
		{
			AddValidPlayerPositions(obj.transform.position, pantsAI);
		}
		else if (obj.CompareTag("Fire"))       //if object making the check is fire, avoid allies + avoid fireAI
		{
			AddValidPlayerPositions(obj.transform.position, fireAI);
		}
		else if (obj.CompareTag("Anvil"))      //if object making the check is anvil, avoid allies + avoid anvilAI
		{
			AddValidPlayerPositions(obj.transform.position, anvilAI);
		}

	}

	//waits for player to click on viable spot
	public IEnumerator waitForClick(System.Action<Vector3> playerPos)
	{
		//If no valid moves
		if (positions[0] == positions[1] && positions[1] == positions[2] && positions[2] == positions[3])
		{
			yield return SkipTurn(pos);
		}
		else
		{
			bool click = false;
			while (!click)
			{
				//checks to see if player clicked on viable spot
				//if so, ends coroutine and passes out the location of the new playerPos
				if (Input.GetMouseButtonDown(0))
				{
					Vector3Int pos = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(-0.5f, 0.5f, 10.0f));
					if (pos.Equals(positions[0]))
					{
						click = true;
						playerPos(positions[0] + Vector3.right);
					}
					if (pos.Equals(positions[1]))
					{
						click = true;
						playerPos(positions[1] + Vector3.right);
					}
					if (pos.Equals(positions[2]))
					{
						click = true;
						playerPos(positions[2] + Vector3.right);
					}
					if (pos.Equals(positions[3]))
					{
						click = true;
						playerPos(positions[3] + Vector3.right);
					}
				}
				yield return null;
			}
		}

		//swaps all green tiles back to grey
		overlayTilemap.SwapTile(greenOverlay, greyOverlay);

	}

	//puts redOverlay on all adjacent tiles and then removes them 0.5f seconds later
	public IEnumerator SkipTurn(Vector3 controllerPos)
	{
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(controllerPos + Vector3.left)))
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(controllerPos + Vector3.left), redOverlay);
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(controllerPos + Vector3.right)))
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(controllerPos + Vector3.right), redOverlay);
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(controllerPos + Vector3.up)))
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(controllerPos + Vector3.up), redOverlay);
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(controllerPos + Vector3.down)))
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(controllerPos + Vector3.down), redOverlay);
		yield return new WaitForSeconds(0.5f);
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(controllerPos + Vector3.left)))
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(controllerPos + Vector3.left), greyOverlay);
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(controllerPos + Vector3.right)))
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(controllerPos + Vector3.right), greyOverlay);
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(controllerPos + Vector3.up)))
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(controllerPos + Vector3.up), greyOverlay);
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(controllerPos + Vector3.down)))
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(controllerPos + Vector3.down), greyOverlay);
	}

	//checks to see of any of the player characters exist at 'pos'
	bool isPlayerNotHere(Vector3 pos)
	{
		return pos != pants.transform.position && pos != fire.transform.position && pos != anvil.transform.position;
	}

	//checks to see of any characters exist at 'pos'
	bool isCharacterNotHere(Vector3 pos)
	{
		return pos != pantsAI.transform.position && pos != fireAI.transform.position && pos != anvilAI.transform.position && isPlayerNotHere(pos);
	}

	//adds all valid moveable tiles to the position array and changes their tile to greenOverlay
	void AddValidPlayerPositions(Vector3 position, GameObject ai)
	{
		//checks and adds upwards tile
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && isPlayerNotHere(position + Vector3.up) && position + Vector3.up != ai.transform.position)
		{
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
			positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
		}

		//checks and adds rightwards tile
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && isPlayerNotHere(position + Vector3.right) && position + Vector3.right != ai.transform.position)
		{
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
			positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
		}

		//checks and adds downwards tile
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && isPlayerNotHere(position + Vector3.down) && position + Vector3.down != ai.transform.position)
		{
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
			positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
		}

		//checks and adds leftwards tile
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && isPlayerNotHere(position + Vector3.left) && position + Vector3.left != ai.transform.position)
		{
			overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
			positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
		}
	}

	//adds all valid moveable tiles to the position array
	void AddValidAIPositions(Vector3 position)
	{
		//checks and adds upwards tile
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && isPlayerNotHere(position + Vector3.up))
		{
			positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
		}

		//checks and adds rightwards tile
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && isPlayerNotHere(position + Vector3.right))
		{
			positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
		}

		//checks and adds downwards tile
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && isPlayerNotHere(position + Vector3.down))
		{
			positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
		}

		//checks and adds leftwards tile
		if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && isPlayerNotHere(position + Vector3.left))
		{
			positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
		}
	}

	Vector3 GetAIMove(Vector3 position)
	{
		pos = position;

		//set every value to <1,1,1> which serves as a null value since no Vector3 generated
		//in this 2D game will have a z component and Vector3 is non-nullable.
		positions = new Vector3Int[] { Vector3Int.one, Vector3Int.one, Vector3Int.one, Vector3Int.one };

		//aggregate valid moves to position array
		AddValidAIPositions(pos);

		float minDist = float.MaxValue;
		Vector3 rtrn = Vector3.one;

		foreach (Vector3 loc in positions)
		{
			if (loc != Vector3.one && Vector3.Distance(pos, loc) < minDist)
			{
				minDist = Vector3.Distance(pos, loc);
				rtrn = loc;
			}
		}


		return rtrn;
	}

}
