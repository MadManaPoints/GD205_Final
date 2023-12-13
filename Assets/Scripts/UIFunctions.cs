using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.UI;

public class UIFunctions : MonoBehaviour
{
    public Button startGameButton;
    public Button resumeButton;
    public Button restartButton;
    public Button settingsButton; 

    public Button quitButton;
    public Button returnButton; 
    public GameObject pause;
    public GameObject ret;
    public GameObject start;

    public GameObject options;

    GameManager gameManager;

    bool inOptions; 
    void Start()
    {
        Button butn = startGameButton.GetComponent<Button>();

        Button resume = resumeButton.GetComponent<Button>();
        Button restart = restartButton.GetComponent<Button>();
        Button settings = settingsButton.GetComponent<Button>();
        Button quit = quitButton.GetComponent<Button>();
        Button returnButn = returnButton.GetComponent<Button>();

        butn.onClick.AddListener(HideButton);

        resume.onClick.AddListener(ResumeGame);
        restart.onClick.AddListener(Reset);
        settings.onClick.AddListener(Settings);
        quit.onClick.AddListener(QuitGame);
        returnButn.onClick.AddListener(Return); 

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        if (gameManager.startGame){
            HideButton(); 
        }

        pause.SetActive(false);
        options.SetActive(false);
    }

    void Update()
    {
        if(gameManager.isPaused){
            PauseGame();
        }
    }

    public void HideButton(){
        ret.SetActive(true);
        start.SetActive(false);
    }

    public void PauseGame(){
        if(inOptions){
            pause.SetActive(false);
        } else {
            pause.SetActive(true); 
        }
        gameManager.startGame = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame(){
        gameManager.startGame = true; 
        pause.SetActive(false);
        gameManager.isPaused = false; 
    }

    public void Reset(){
        gameManager.reset = true;
        gameManager.isPaused = false; 
        gameManager.startGame = true;
        Destroy(start.gameObject);
    }

    public void Settings(){
        inOptions = true; 
        pause.SetActive(false);
        options.SetActive(true);
    }

    public void Return(){
        inOptions = false; 
        pause.SetActive(true);
        options.SetActive(false);
    }

    public void QuitGame(){
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("YEERR");
        Application.Quit();
    }
}
