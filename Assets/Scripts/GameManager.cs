using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public bool levelTwo;
    public bool startGame;

    void Start(){
        if(levelTwo){
            startGame = true;
        }
    }
    void Awake()
    {
        GameObject [] objs = GameObject.FindGameObjectsWithTag("Game Manager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Update(){
        if(levelTwo){
            LoadScenes();
            levelTwo = false; 
        }
    }

    void LoadScenes(){
        SceneManager.LoadScene("Test");
    }

    public void Click(){
        startGame = true; 
    }
}
