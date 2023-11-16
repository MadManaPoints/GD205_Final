using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptRedBook : MonoBehaviour
{
    public ParticleSystem corruptRedBook;
    private GameManager gameManager; 
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        //corruptRedBook.Play(); idk why this doesn't work 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
