using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public bool letThereBeLight;
    public bool teleporterOn;
    public bool openSesame;
    public bool levelTwo; 
    [SerializeField] GameObject teleporters;
    [SerializeField] GameObject directionalLightObj;
    [SerializeField] Material skyBoxOne;
    [SerializeField] Material skyBoxTwo; 
    private Light directionalLight;
    private int startLightIntensity = 0;
    private float newLightIntensity = 0.8f;

    void Start()
    {
        directionalLight = directionalLightObj.GetComponent<Light>();
        RenderSettings.skybox = skyBoxOne;
        DynamicGI.UpdateEnvironment();
        directionalLight.intensity = startLightIntensity;
    }

    
    void Update()
    {
        if(letThereBeLight){
            directionalLight.intensity = newLightIntensity;
            RenderSettings.skybox = skyBoxTwo;
            DynamicGI.UpdateEnvironment();
            directionalLight.intensity = newLightIntensity;
        }

        if(teleporterOn){
            teleporters.SetActive(true);
        }

        UpdateLevel();
    }

    void UpdateLevel(){
        if(levelTwo){
            SceneManager.LoadScene("Test", LoadSceneMode.Single);
        }
    }
}
