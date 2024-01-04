using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSens : MonoBehaviour
{
    public Slider slider;
    PlayerController player;
    void Start()
    {
        slider.onValueChanged.AddListener(AdjustSens);
        player = GameObject.Find("Player Cam").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //player can adjust sensitivity in settings 
        slider.value = player.sens / 10;
    }

    public void AdjustSens(float newSpeed){
        player.sens = newSpeed * 10f;
    }
}
