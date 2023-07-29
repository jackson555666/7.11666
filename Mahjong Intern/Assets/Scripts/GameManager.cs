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

    public TileGameObject selectedTile;
    public GameObject discardPile;
    [SerializeField] GameObject localPlayerHand;
    [SerializeField] List<PlayerController> playerControllers = new List<PlayerController>();

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
            
        }
        else
        {
            //multiple tiles to 4 set of tiles (136 tiles)
            for (int i = 0; i < 2; i++)
            {
                DrawPileList.AddRange(DrawPileList);
            }

            TempDrawPileList.Clear();
            TempDrawPileList.AddRange(DrawPileList);

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
    }

    void GivePlayerTiles()
    {
        int randomNumber;//for random index of tile in DrawPileList

        for (int l = 0; l < playerControllers.Count; l++)
        {
            for (int i = 0; i < 13; i++)
            {
                if (isMockingGame)
                {
                    randomNumber = Random.Range(0, MockDrawPileList.Count);

                    TileObject newTileObject = MockDrawPileList[randomNumber];//get the tileObject at specific index

                    playerControllers[l].AddTileToPlayerHand(newTileObject);

                    //remove the tile from DrawPileList
                    MockDrawPileList.Remove(MockDrawPileList[randomNumber]);
                }
                else
                {
                    randomNumber = Random.Range(0, DrawPileList.Count);//random index from DrawPileList

                    TileObject newTileObject = DrawPileList[randomNumber];//get the tileObject at specific index

                    playerControllers[l].AddTileToPlayerHand(newTileObject);

                    //remove the tile from DrawPileList
                    DrawPileList.Remove(DrawPileList[randomNumber]);
                }
            }

            playerControllers[l].CheckPlayerHand();
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
