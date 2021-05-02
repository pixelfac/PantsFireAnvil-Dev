using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridOverlayBehavior : MonoBehaviour
{

    public Tile greyOverlay, greenOverlay;
    public Tilemap overlayTilemap, obstacleTilemap;
    public GameObject GridOwner;
    Grid2D grid;
    public GameObject pants, fire, anvil, pantsAI, fireAI, anvilAI;
    Vector3Int[] positions = new Vector3Int[4];

    

    void Awake()
    {
        //Instantiate grid
        grid = GridOwner.GetComponent<Grid2D>();
    }


    //overlays in green the tiles that the character can move to
    //and adds that world position to an array for later checking in method:waitForClick()
    public void showPlayerMovementArea(Vector3 position, GameObject obj)
    {
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
            //checks and adds upwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pants.transform.position && position + Vector3.up != fire.transform.position && position + Vector3.up != anvil.transform.position && position + Vector3.up != fireAI.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
                positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
            }

            //checks and adds rightwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pants.transform.position && position + Vector3.right != fire.transform.position && position + Vector3.right != anvil.transform.position && position + Vector3.right != fireAI.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
                positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
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
        bool click = false;
        while (!click)
        {
            //checks to see if player clicked on viable spot
            //if so, ends coroutine and passes out the location of the new playerPos
            if (Input.GetMouseButtonDown(0))
            {
                Vector3Int pos = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(-0.5f,0.5f,5.5f));
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
        //swaps all green tiles back to grey
        overlayTilemap.SwapTile(greenOverlay, greyOverlay);
        
    }

}
