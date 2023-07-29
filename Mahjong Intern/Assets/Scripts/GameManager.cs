using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isMockingGame;

    [SerializeField] GameObject tileObjectPrefab;

    TileGameObject selectedTile;
    public GameObject discardPile;
    [SerializeField] GameObject localPlayerHand;

    public List<TileObject> DrawPileList = new List<TileObject>();
    public List<TileObject> TempDrawPileList = new List<TileObject>();
    public List<TileObject> MockDrawPileList = new List<TileObject>();
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
        ShuffleThePile();
        TimerOn = true;     //On Timer countdown

        GivePlayerTiles();//give main player tiles
    }

    void ShuffleThePile()
    {
        if(isMockingGame)
        {
            //TODO: give tiles to player from mocking pile
        }
        else
        {
            //multiple tiles to 4 set of tiles (136 tiles)
            for (int i = 0; i < 2; i++)
            {
                DrawPileList.AddRange(DrawPileList);
            }

            List<int> usedIndex = new List<int>();


            foreach(TileObject tileObj in DrawPileList)
            {
                bool isIndexEmpty = true;
                int randomIndex;

                do
                {
                    randomIndex = Random.Range(0, DrawPileList.Count);

                    if (!usedIndex.Contains(randomIndex))
                    {
                        TempDrawPileList[randomIndex] = tileObj;
                        usedIndex.Add(randomIndex);
                        isIndexEmpty = true;
                    }
                    else
                        isIndexEmpty = false;
                }
                while (!isIndexEmpty);
            }

            DrawPileList = TempDrawPileList;
        }

        Debug.Log("Done Shuffling");
    }

    void GivePlayerTiles()
    {
        int randomNumber;//for random index of tile in DrawPileList

        for (int i = 0;i<13;i++)
        {
            randomNumber = Random.Range(0, DrawPileList.Count);//random index from DrawPileList
            TileObject newTileObject = DrawPileList[randomNumber];//get the tileObject at specific index

            //create a new tile game object in the scene. and get TileGameObject component so we can use its function later
            TileGameObject newTile = Instantiate(tileObjectPrefab.GetComponent<TileGameObject>(),localPlayerHand.transform);
            //use TileGameObject function in newTile
            newTile.SetupTile(newTileObject);

            //remove the tile from DrawPileList
            DrawPileList.Remove(DrawPileList[randomNumber]);
        }
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
