using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerHand;
    List<TileObject> playerTileList = new List<TileObject>();

    TileObject lowestTile;
    TileObject highestTile;

    public void CheckPlayerHand()
    {
        //TODO: sort player tile
        //TODO: check player hand combination
        //and if this player hand is complete, let them summit their hand to GameManager

        lowestTile = playerTileList[0];
        highestTile = playerTileList[playerTileList.Count - 1];

        for(int i = 0;i< playerTileList.Count;i++)
        {
            CompareTile(playerTileList[i]);
        }
    }

    void CompareTile(TileObject tileA)
    {
        if(tileA.tileType < lowestTile.tileType)
        {
            SetToFirst();
        }
        else if (tileA.tileType > highestTile.tileType)
        {
            SetToLast();
        }
        else if(tileA.tileType == lowestTile.tileType)
        {
            if(tileA.tileNumber > 0 && tileA.tileNumber < lowestTile.tileNumber)
            {

            }
        }

        void SetToFirst()
        {
            tileA.tileGameObject.transform.SetAsFirstSibling();
            lowestTile = tileA;
        }
        void SetToLast()
        {
            tileA.tileGameObject.transform.SetAsLastSibling();
            highestTile = tileA;
        }
    }
}
