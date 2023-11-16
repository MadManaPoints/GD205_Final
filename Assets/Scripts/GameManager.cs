using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public bool letThereBeLight;
    public bool teleporterOn;
    public bool openSesame;
    [SerializeField] GameObject teleporters;
    [SerializeField] GameObject thanks; 
    void Start()
    {
        
    }

    
    void Update()
    {
        if(letThereBeLight){
            RenderSettings.skybox.SetFloat("_Exposure", 1.4f);
            DynamicGI.UpdateEnvironment();
        } else {
            RenderSettings.skybox.SetFloat("_Exposure", 0f);
            DynamicGI.UpdateEnvironment();
        }

        if(teleporterOn){
            teleporters.SetActive(true);
        }

        if(openSesame){
            thanks.SetActive(true);
        }
    }
}
