using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    TileGameObject selectedTile;
    public GameObject discardPile;

    public List<TileGameObject> discardTileList = new List<TileGameObject>();   

    public float timeLeft = 30.0f;  //assign float "timeLeft" as 30.0
    public TMP_Text TimerText;  //used to show for countdown
    public bool TimerOn = false;    //assign boolean "TimerOn" as false


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
        TimerOn = true;     //On Timer countdown
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

    private void Update()
    {
        if (TimerOn == true)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                TimerText.SetText("Timer: " + timeLeft.ToString("0"));
            }
            else
            {
                timeLeft = 0;
                TimerText.SetText("Timer: " + timeLeft.ToString("0"));
                //Do something after time countdown
            }
        }
    }
}
