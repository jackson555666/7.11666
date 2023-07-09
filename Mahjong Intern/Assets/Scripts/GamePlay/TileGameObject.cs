using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TileGameObject : MonoBehaviour 
{
    TileObject tileObject;
    [SerializeField] GameObject TileGraphic;
    public TextMeshProUGUI tileSymbolText;
    [SerializeField] bool isSelected;

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
        TileGraphic.transform.position = new Vector2(TileGraphic.transform.position.x, TileGraphic.transform.position.y + 20);
    }
    public void MoveTileDown()
    {
        TileGraphic.transform.position = new Vector2(TileGraphic.transform.position.x, TileGraphic.transform.position.y - 20);
    }

}

[Serializable]
public class TileObject
{
    public TileType tileType;
    public int tileNumber;
    public TileDirection direction;
    public GameObject tileSymbol;

    public TileObject(TileType tileType, int tileNumber)
    {
        this.tileType = tileType;
        this.tileNumber = tileNumber;
    }
}

public enum TileType
{
    Elephant,
    Flower,
    Number,
    Direction,
    Tuktuk,
    Mango,
    Mangosteen
}

public enum TileDirection
{
    Up,
    Down,
    Left,
    Right
}
