using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterSwitch : MonoBehaviour
{
    private SceneOneManager sceneManager;
    [SerializeField] GameObject teleporterObj;
    ParticleSystem teleporter; 
    void Start()
    {
        sceneManager = GameObject.Find("Scene One Manager").GetComponent<SceneOneManager>();
        teleporter = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        if(sceneManager.teleporterOn){
            if(!teleporter.isPlaying){
                teleporter.Play();
            }
        }
    }
}
