using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPack : MonoBehaviour
{
    //
    Rigidbody2D rigidbody;
    public ParticleSystem particleSystem;

    //Jetpack
    public float jetpackForce;
    public float jetpackFuel, jetpackStartFuel, jetpackFillingSpeed, jetpackFuelSpendingSpeed;

    //Checking
    Boolean jetpackFull = true;

    //Fuel UI
    public Slider slider;


    
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        particleSystem.Stop();

        jetpackFuel = jetpackStartFuel;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Functions
        JetPackUse();
        SetFuelUI();
    }

    void JetPackUse()
    {

        if(jetpackFuel >= jetpackStartFuel)
        {
            jetpackFull = true;
        }
        else
        {
            jetpackFull = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jetpackFuel > 0)
            {
                rigidbody.AddForce(new Vector2(0, jetpackForce), ForceMode2D.Force);
                jetpackFuel -= jetpackFuelSpendingSpeed * Time.deltaTime;
                //for particles
                particleSystem.Play();
                
            }
            

        }
        else
        {
            
            if (jetpackFull == false)
            {
                jetpackFuel += jetpackFillingSpeed * Time.deltaTime;
            }
            
            
        }
       
    }
    void SetFuelUI()
    {
        slider.maxValue = jetpackStartFuel;
        slider.value = jetpackFuel;

    }
        
}
