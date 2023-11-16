using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class TeleporterSwitch : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] GameObject teleporters; 
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        if(gameManager.teleporterOn){
            Debug.Log("ON!");
            teleporters.SetActive(true); 
        }
    }
}
