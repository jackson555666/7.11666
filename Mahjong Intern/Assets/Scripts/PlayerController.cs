using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool isLocalPlayer;

    [SerializeField] GameObject playerHand;
    [SerializeField] GameObject tileObjectPrefab;
    public List<TileObject> playerTileList = new List<TileObject>();
    public List<TilesCombination> tilesCombinations = new List<TilesCombination>();

    public void AddTileToPlayerHand(TileObject newTileData)
    {
        if (isLocalPlayer)
        {
            //create a new tile game object in the scene. and get TileGameObject component so we can use its function later
            TileGameObject newTileGameObject = Instantiate(tileObjectPrefab.GetComponent<TileGameObject>(), this.transform);
            //use TileGameObject function in newTile
            newTileGameObject.SetupTile(newTileData);
            playerTileList.Add(newTileGameObject.tileObject);
        }
        else
            playerTileList.Add(newTileData);
    }


    public void CheckPlayerHand()
    {
        SortingTiles();
        CheckTilesCombination();
        //TODO: check player hand combination
        //and if this player hand is complete, let them summit their hand to GameManager
    }

    public void SortingTiles()
    {
        Debug.Log("sorting");
        
        int lowestTileIndex = 0;

        for(int i = 0;i < playerTileList.Count - 1;i++)
        {
            lowestTileIndex = i;

            for(int j = i+1; j < playerTileList.Count;j++)
            {
                if(!CompareTile(playerTileList[lowestTileIndex], playerTileList[j]))
                {
                    lowestTileIndex = j;
                }
            }

            TileObject tempTile = playerTileList[lowestTileIndex];
            playerTileList.RemoveAt(lowestTileIndex);
            playerTileList.Insert(i, tempTile);

            if(isLocalPlayer)
                playerTileList[i].tileGameObject.transform.SetSiblingIndex(i);
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

    void CheckTilesCombination()
    {
        for(int i = 0; i < playerTileList.Count; i++)
        {
            TilesCombination combinationSet = new TilesCombination();
            combinationSet.tileObjects.Add(playerTileList[i]);
            tilesCombinations.Add(combinationSet);

            if (i == playerTileList.Count - 1)
                return;

            for (int j = i+1; j < playerTileList.Count; j++)
            {
                if (playerTileList[i].tileType == playerTileList[j].tileType)
                {
                    combinationSet.tileObjects.Add(playerTileList[j]);
                }
                else
                {
                    i += j - 1;
                    j = playerTileList.Count;
                }
            }
        }
    }
}

[Serializable]
public class TilesCombination
{
    public List<TileObject> tileObjects = new List<TileObject>();
}
