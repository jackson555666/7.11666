using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TileGameObject : MonoBehaviour 
{
    public TileObject tileObject;
    [SerializeField] GameObject TileGraphic;
    public GameObject tileGraphicGroup;
    [SerializeField] bool isSelected;

    public void SetupTile(TileObject newTileObject)
    {
        this.tileObject.tileType= newTileObject.tileType;
        this.tileObject.tileSymbol = newTileObject.tileSymbol;
        this.tileObject.tileNumber = newTileObject.tileNumber;
        this.tileObject.direction = newTileObject.direction;
        this.tileObject.tileGameObject = this.gameObject;

        if(newTileObject.tileSymbol != null)
        Instantiate(newTileObject.tileSymbol, tileGraphicGroup.transform);//create symbol on the tile
    }

    //run when select a tile. Assigned to tileObject's button.
    public void SelectThisTile()
    {
        SoundManager.Instance.PlaySoundFromList(SoundNameEnum.tileClick);

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
        TileGraphic.transform.position = new Vector2(TileGraphic.transform.position.x, TileGraphic.transform.position.y + 70);
    }
    public void MoveTileDown()
    {
        isSelected = false;
        TileGraphic.transform.position = new Vector2(TileGraphic.transform.position.x, TileGraphic.transform.position.y - 70);
    }

}

[Serializable]
public class TileObject
{
    public TileType tileType;
    public int tileNumber;
    public TileDirection direction;
    public GameObject tileSymbol;
    public GameObject tileGameObject;

    public TileObject(TileType tileType, int tileNumber)
    {
        this.tileType = tileType;
        this.tileNumber = tileNumber;
    }
}

public enum TileType
{
    Elephant,//9*4 tiles
    Flower,//9*4 tiles
    Number,//9*4 tiles
    Direction,//4 directions, 4 tiles for each direction, 4 set
    Tuktuk,//4*4 tiles
    Mango,//4*4 tiles
    Mangosteen//4*4 tiles
}

public enum TileDirection
{
    Up,
    Down,
    Left,
    Right
}
