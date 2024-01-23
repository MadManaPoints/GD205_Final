using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool levelTwo;
    public bool startGame;
    public bool isPaused; 
    public bool reset;

    void Start(){
        if(levelTwo){
            startGame = true;
        } 
        
        else {
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

        if(reset){
            ResetScenes();
            reset = false;
        }

        if(Input.GetKeyDown(KeyCode.Tab) && !isPaused && startGame){
            isPaused = true;
        }
    }

    void LoadScenes(){
        SceneManager.LoadScene("Test");
    }

    void ResetScenes(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Click(){
        startGame = true; 
        //Destroy(gameObject);
    }
}
