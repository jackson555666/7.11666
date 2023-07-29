using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerHand;
    [SerializeField] GameObject tileObjectPrefab;
    public List<TileObject> playerTileList = new List<TileObject>();

    //TileObject lowestTile;
    //TileObject highestTile;

    public void AddTileToPlayerHand(TileObject newTileData)
    {
        //create a new tile game object in the scene. and get TileGameObject component so we can use its function later
        TileGameObject newTileGameObject = Instantiate(tileObjectPrefab.GetComponent<TileGameObject>(), this.transform);
        //use TileGameObject function in newTile
        newTileGameObject.SetupTile(newTileData);

        playerTileList.Add(newTileGameObject.tileObject);
    }


    public void CheckPlayerHand()
    {
        //TODO: sort player tile
        //TODO: check player hand combination
        //and if this player hand is complete, let them summit their hand to GameManager

        //lowestTile = playerTileList[0];
        //highestTile = playerTileList[playerTileList.Count - 1];

        SortingTiles();
        //TODO: check tiles combination
    }

    public void SortingTiles()
    {
        int lowestTileIndex = 0;

        for(int i = 0;i < playerTileList.Count;i++)
        {
            lowestTileIndex = i;

            for(int j = 1; j < playerTileList.Count;j++)
            {
                if(!CompareTile(playerTileList[lowestTileIndex], playerTileList[lowestTileIndex + 1]))
                {
                    lowestTileIndex = j;
                }
            }

            TileObject tempTile = playerTileList[lowestTileIndex];
            playerTileList.RemoveAt(lowestTileIndex);
            playerTileList.Insert(0, tempTile);
        }
    }

    bool CompareTile(TileObject tileA, TileObject tileB)//return true if A < B
    {
        if(tileA.tileType < tileB.tileType)
        {
            return true;
        }
        else if (tileA.tileType > tileB.tileType)
        {
            return false;
        }
        else if(tileA.tileType == tileB.tileType)
        {
            if(tileA.tileType == TileType.Elephant || tileA.tileType == TileType.Flower || tileA.tileType == TileType.Number)
            {
                if(tileA.tileNumber < tileB.tileNumber)
                    return true;
                else
                    return false;
            }
            else if(tileA.tileType == TileType.Direction)
            {
                if (tileA.direction < tileB.direction)
                    return true;
                else
                    return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
