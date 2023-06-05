using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hello : MonoBehaviour
{
    //public string lobby;
    [SerializeField] string sceneName;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message: "Hello world");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void sceneChanging()
    {
        SceneManager.LoadScene(sceneName);
    }
}


