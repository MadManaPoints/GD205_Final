using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    public Button buttonOne; 
    public Button buttonTwo;


    public GameObject button; 
    void Start()
    {
        //buttonOne = GameObject.Find("Button").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeButton(){
        //buttonOne.text = "Yer"; 
    }
}
