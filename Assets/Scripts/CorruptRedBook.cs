using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptRedBook : MonoBehaviour
{
    public ParticleSystem corruptRedBook;
    private SceneOneManager sceneManager; 
    void Start()
    {
        sceneManager = GameObject.Find("Scene One Manager").GetComponent<SceneOneManager>(); 
        //corruptRedBook.Play(); idk why this doesn't work 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
