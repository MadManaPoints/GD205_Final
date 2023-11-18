using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterSwitch : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] GameObject teleporterObj;
    ParticleSystem teleporter; 
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        teleporter = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        if(gameManager.teleporterOn){
            if(!teleporter.isPlaying){
                teleporter.Play();
            }
        }
    }
}
