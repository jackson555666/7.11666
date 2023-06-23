using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;SceneManagement

public class ChangeScene : MonoBehaviour
{
    //public string sceneName;
    [SerializeField] string InGame;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world")
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hello world");
    }
    public void InGame()
    {
        SceneManager.LoadScene(InGame);
    }
}
