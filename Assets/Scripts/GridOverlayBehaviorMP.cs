using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridOverlayBehaviorMP : MonoBehaviour
{

    public Tile greyOverlay, greenOverlay;
    public Tilemap overlayTilemap, obstacleTilemap;
    public GameObject GridOwner;
    Grid2D grid;
    public GameObject pantsBlu, fireBlu, anvilBlu, pantsRed, fireRed, anvilRed;
    Vector3Int[] positions = new Vector3Int[4] {new Vector3Int(50,50,50), new Vector3Int(50, 50, 50), new Vector3Int(50, 50, 50), new Vector3Int(50, 50, 50) };

    

    void Awake()
    {
        //Instantiate grid
        grid = GridOwner.GetComponent<Grid2D>();
    }


    //overlays in green the tiles that the character can move to
    //and adds that world position to an array for later checking in method:waitForClick()
    public void showPlayerMovementArea(Vector3 position, GameObject obj)
    {
        //if object making the check is pantsBlu, avoid allies + avoid pantsRed
        if (obj == pantsBlu)
        {
            //checks and adds upwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pantsBlu.transform.position && position + Vector3.up != fireBlu.transform.position && position + Vector3.up != anvilBlu.transform.position && position + Vector3.up != pantsRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
                positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
            }

            //checks and adds rightwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pantsBlu.transform.position && position + Vector3.right != fireBlu.transform.position && position + Vector3.right != anvilBlu.transform.position && position + Vector3.right != pantsRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
                positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
            }

            //checks and adds downwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pantsBlu.transform.position && position + Vector3.down != fireBlu.transform.position && position + Vector3.down != anvilBlu.transform.position && position + Vector3.down != pantsRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
                positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
            }

            //checks and adds leftwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pantsBlu.transform.position && position + Vector3.left != fireBlu.transform.position && position + Vector3.left != anvilBlu.transform.position && position + Vector3.left != pantsRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
                positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
            }
        }
        else if (obj == fireBlu)       //if object making the check is fireBlu, avoid allies + avoid fireRed
        {
            //checks and adds upwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pantsBlu.transform.position && position + Vector3.up != fireBlu.transform.position && position + Vector3.up != anvilBlu.transform.position && position + Vector3.up != fireRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
                positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
            }

            //checks and adds rightwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pantsBlu.transform.position && position + Vector3.right != fireBlu.transform.position && position + Vector3.right != anvilBlu.transform.position && position + Vector3.right != fireRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
                positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
            }

            //checks and adds downwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pantsBlu.transform.position && position + Vector3.down != fireBlu.transform.position && position + Vector3.down != anvilBlu.transform.position && position + Vector3.down != fireRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
                positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
            }

            //checks and adds leftwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pantsBlu.transform.position && position + Vector3.left != fireBlu.transform.position && position + Vector3.left != anvilBlu.transform.position && position + Vector3.left != fireRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
                positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
            }
        }
        else if (obj == anvilBlu)      //if object making the check is anvilBlu, avoid allies + avoid anvilRed
        {
            //checks and adds upwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pantsBlu.transform.position && position + Vector3.up != fireBlu.transform.position && position + Vector3.up != anvilBlu.transform.position && position + Vector3.up != anvilRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
                positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
            }

            //checks and adds rightwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pantsBlu.transform.position && position + Vector3.right != fireBlu.transform.position && position + Vector3.right != anvilBlu.transform.position && position + Vector3.right != anvilRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
                positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
            }

            //checks and adds downwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pantsBlu.transform.position && position + Vector3.down != fireBlu.transform.position && position + Vector3.down != anvilBlu.transform.position && position + Vector3.down != anvilRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
                positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
            }

            //checks and adds leftwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pantsBlu.transform.position && position + Vector3.left != fireBlu.transform.position && position + Vector3.left != anvilBlu.transform.position && position + Vector3.left != anvilRed.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
                positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
            }
        }

        else if (obj == pantsRed)   //if object making the check is pants, avoid allies + avoid pantsAI

        {
            //checks and adds upwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pantsRed.transform.position && position + Vector3.up != fireRed.transform.position && position + Vector3.up != anvilRed.transform.position && position + Vector3.up != pantsBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
                positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
            }

            //checks and adds rightwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pantsRed.transform.position && position + Vector3.right != fireRed.transform.position && position + Vector3.right != anvilRed.transform.position && position + Vector3.right != pantsBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
                positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
            }

            //checks and adds downwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pantsRed.transform.position && position + Vector3.down != fireRed.transform.position && position + Vector3.down != anvilRed.transform.position && position + Vector3.down != pantsBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
                positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
            }

            //checks and adds leftwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pantsRed.transform.position && position + Vector3.left != fireRed.transform.position && position + Vector3.left != anvilRed.transform.position && position + Vector3.left != pantsBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
                positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
            }
        }
        else if (obj == fireRed)       //if object making the check is fire, avoid allies + avoid fireAI
        {
            //checks and adds upwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pantsRed.transform.position && position + Vector3.up != fireRed.transform.position && position + Vector3.up != anvilRed.transform.position && position + Vector3.up != fireBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
                positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
            }

            //checks and adds rightwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pantsRed.transform.position && position + Vector3.right != fireRed.transform.position && position + Vector3.right != anvilRed.transform.position && position + Vector3.right != fireBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
                positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
            }

            //checks and adds downwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pantsRed.transform.position && position + Vector3.down != fireRed.transform.position && position + Vector3.down != anvilRed.transform.position && position + Vector3.down != fireBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
                positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
            }

            //checks and adds leftwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pantsRed.transform.position && position + Vector3.left != fireRed.transform.position && position + Vector3.left != anvilRed.transform.position && position + Vector3.left != fireBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.left), greenOverlay);
                positions[3] = overlayTilemap.WorldToCell(position + Vector3.left);
            }
        }
        else if (obj == anvilRed)      //if object making the check is anvil, avoid allies + avoid anvilAI

        {
            //checks and adds upwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.up)) && position + Vector3.up != pantsRed.transform.position && position + Vector3.up != fireRed.transform.position && position + Vector3.up != anvilRed.transform.position && position + Vector3.up != anvilBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.up), greenOverlay);
                positions[0] = overlayTilemap.WorldToCell(position + Vector3.up);
            }

            //checks and adds rightwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.right)) && position + Vector3.right != pantsRed.transform.position && position + Vector3.right != fireRed.transform.position && position + Vector3.right != anvilRed.transform.position && position + Vector3.right != anvilBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.right), greenOverlay);
                positions[1] = overlayTilemap.WorldToCell(position + Vector3.right);
            }

            //checks and adds downwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.down)) && position + Vector3.down != pantsRed.transform.position && position + Vector3.down != fireRed.transform.position && position + Vector3.down != anvilRed.transform.position && position + Vector3.down != anvilBlu.transform.position)
            {
                overlayTilemap.SetTile(overlayTilemap.WorldToCell(position + Vector3.down), greenOverlay);
                positions[2] = overlayTilemap.WorldToCell(position + Vector3.down);
            }

            //checks and adds leftwards tile
            if (!obstacleTilemap.HasTile(obstacleTilemap.WorldToCell(position + Vector3.left)) && position + Vector3.left != pantsRed.transform.position && position + Vector3.left != fireRed.transform.position && position + Vector3.left != anvilRed.transform.position && position + Vector3.left != anvilBlu.transform.position)
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
