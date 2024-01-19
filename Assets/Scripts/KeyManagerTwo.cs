using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerTwo : MonoBehaviour
{

    public int levelTwoKeys = 0;
    [SerializeField] Material yellow; 
    [SerializeField] GameObject [] keys;
    [SerializeField] GameObject altarBook;
    bool bookActive; 
    void Start()
    {
        altarBook.SetActive(false);
    }

    
    void Update()
    {
        if(levelTwoKeys == 3){
            keys[4].GetComponent<Renderer>().material = yellow;
            keys[5].GetComponent<Renderer>().material = yellow;

            altarBook.SetActive(true);
            bookActive = true; 
        } else if(levelTwoKeys == 2){
            keys[2].GetComponent<Renderer>().material = yellow;
            keys[3].GetComponent<Renderer>().material = yellow; 
        } else if(levelTwoKeys == 1){
            keys[0].GetComponent<Renderer>().material = yellow;
            keys[1].GetComponent<Renderer>().material = yellow; 
        }
    }
}
