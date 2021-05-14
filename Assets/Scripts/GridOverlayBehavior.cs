﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridOverlayBehavior : MonoBehaviour
{

	[SerializeField] private Tile greyOverlay, greenOverlay, redOverlay;
	[SerializeField] private Tilemap overlayTilemap, obstacleTilemap;
	[SerializeField] private GameObject pants, fire, anvil, pantsAI, fireAI, anvilAI;
	Vector3Int[] positions;
	Vector3 pos;


	//overlays in green the tiles that the character can move to
	//and adds that world position to an array for later checking in method:waitForClick()
	public void showPlayerMovementArea(Vector3 position, GameObject obj)
	{
		pos = position;
		//set every value to <1,1,1> which serves as a null value since no Vector3 generated
		//in this 2D game will have a z component.
		positions = new Vector3Int[] { Vector3Int.one, Vector3Int.one, Vector3Int.one, Vector3Int.one};


		//if object making the check is pants, avoid allies + avoid pantsAI
		if (obj == pants)
		{
			//checks and adds upwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pants.transform.position && position + Vector3.up != fire.transform.position && position + Vector3.up != anvil.transform.position && position + Vector3.up != pantsAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
				positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
			}

			//checks and adds rightwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pants.transform.position && position + Vector3.right != fire.transform.position && position + Vector3.right != anvil.transform.position && position + Vector3.right != pantsAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
				positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
			}

			//checks and adds downwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pants.transform.position && position + Vector3.down != fire.transform.position && position + Vector3.down != anvil.transform.position && position + Vector3.down != pantsAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
				positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
			}

			//checks and adds leftwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pants.transform.position && position + Vector3.left != fire.transform.position && position + Vector3.left != anvil.transform.position && position + Vector3.left != pantsAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
				positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
			}
		}
		else if (obj == fire)       //if object making the check is fire, avoid allies + avoid fireAI
		{
			Debug.Log("Fire Confirmed");

			//checks and adds upwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pants.transform.position && position + Vector3.up != fire.transform.position && position + Vector3.up != anvil.transform.position && position + Vector3.up != fireAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
				positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
			}

			//checks and adds rightwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pants.transform.position && position + Vector3.right != fire.transform.position && position + Vector3.right != anvil.transform.position && position + Vector3.right != fireAI.transform.position)
			{
				Debug.Log("right is good");
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
				positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
				Debug.Log("pos[1] is set");
			}

			//checks and adds downwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pants.transform.position && position + Vector3.down != fire.transform.position && position + Vector3.down != anvil.transform.position && position + Vector3.down != fireAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
				positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
			}

			//checks and adds leftwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pants.transform.position && position + Vector3.left != fire.transform.position && position + Vector3.left != anvil.transform.position && position + Vector3.left != fireAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
				positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
			}
		}
		else if (obj == anvil)      //if object making the check is anvil, avoid allies + avoid anvilAI
		{
			//checks and adds upwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pants.transform.position && position + Vector3.up != fire.transform.position && position + Vector3.up != anvil.transform.position && position + Vector3.up != anvilAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
				positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
			}

			//checks and adds rightwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pants.transform.position && position + Vector3.right != fire.transform.position && position + Vector3.right != anvil.transform.position && position + Vector3.right != anvilAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
				positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
			}

			//checks and adds downwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pants.transform.position && position + Vector3.down != fire.transform.position && position + Vector3.down != anvil.transform.position && position + Vector3.down != anvilAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
				positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
			}

			//checks and adds leftwards tile
			if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pants.transform.position && position + Vector3.left != fire.transform.position && position + Vector3.left != anvil.transform.position && position + Vector3.left != anvilAI.transform.position)
			{
				overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
				positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
			}
		}

	}

	//waits for player to click on viable spot
	public IEnumerator waitForClick(System.Action<Vector3> playerPos)
	{
		Debug.Log(positions[0]);
		Debug.Log(positions[1]);
		Debug.Log(positions[2]);
		Debug.Log(positions[3]);
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

	public IEnumerator SkipTurn(Vector3 controllerPos)
	{
		//puts redOverlay on all adjacent tiles and then removes them 0.5f seconds later
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

}
