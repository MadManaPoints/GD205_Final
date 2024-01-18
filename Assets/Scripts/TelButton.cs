using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelButton : MonoBehaviour
{
    [SerializeField] GameObject teleporter;
    ParticleSystem beam;
    public bool telTwoOn; 
    [SerializeField] Material red;
    [SerializeField] Material green; 
    Vector3 startPos;
    Vector3 newPos; 
    [SerializeField] bool pressed;

    void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(startPos.x, startPos.y - 0.129f, startPos.z);

        beam = teleporter.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed){
            GetComponent<Renderer>().material = green;
            transform.position = newPos;
            
            if(!beam.isPlaying){
                beam.Play();
                telTwoOn = true;
            }
        } else if(!pressed){
            GetComponent<Renderer>().material = red;
            transform.position = startPos;
            
            if(beam.isPlaying){
                beam.Stop();
                telTwoOn = false; 
            } 
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Box"){
            pressed = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Box"){
            pressed = false; 
        }
    } 
}
