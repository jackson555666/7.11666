using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileGameObject : MonoBehaviour 
{
    TileObject tileObject;
    [SerializeField] GameObject TileGraphic;
    public TextMeshProUGUI tileSymbolText;
    [SerializeField] bool isSelected;

    //run when select a tile. Assigned to tileObject's button.
    public void SelectThisTile()
    {
        if (!isSelected)
        {
            isSelected = true;
            GameManager.Instance.SelectTileToDiscard(this);
        }
        else
        {
            isSelected = false;
            GameManager.Instance.DeselectTileToDiscard();
        }
    }

    //highlight which tile is selected
    public void MoveTileUp()
    {
        TileGraphic.transform.position = new Vector2(TileGraphic.transform.position.x, TileGraphic.transform.position.y + 20);
    }
    public void MoveTileDown()
    {
        TileGraphic.transform.position = new Vector2(TileGraphic.transform.position.x, TileGraphic.transform.position.y - 20);
    }

}

public class TileObject
{
    public TileType tileType;
    public int tileNumber;

    public TileObject(TileType tileType, int tileNumber)
    {
        this.tileType = tileType;
        this.tileNumber = tileNumber;
    }
}

public enum TileType
{
    Dot,
    Bamboo,
    Number
}
