using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFunctions : MonoBehaviour
{
    public Button startGameButton;
    public GameObject ret; 
    void Start()
    {
        Button butn = startGameButton.GetComponent<Button>();
        butn.onClick.AddListener(HideButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideButton(){
        ret.SetActive(true); 
        Destroy(gameObject);
    }
}
