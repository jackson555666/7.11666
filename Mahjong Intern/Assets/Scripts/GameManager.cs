using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TileGameObject selectedTile;
    public GameObject discardPile;

    public List<TileGameObject> discardTileList = new List<TileGameObject>();

    //for create Singleton pattern, only one of this script instance can exist in a scene
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        
    }

    public void DiscardATile()
    {
        if (selectedTile == null)
        {
            Debug.Log("Not selected card yet!");
            return;
        }

        discardTileList.Add(selectedTile);
        selectedTile.gameObject.transform.parent = discardPile.transform;
        DeselectTileToDiscard();
    }

    public void SelectTileToDiscard(TileGameObject newSelectedTile)
    {
        if(selectedTile != null)
        {
            DeselectTileToDiscard();
        }

        newSelectedTile.MoveTileUp();
        selectedTile = newSelectedTile;
    }

    public void DeselectTileToDiscard()
    {
        if (selectedTile == null)
            return;

        selectedTile.MoveTileDown();
        selectedTile = null;
    }
}
