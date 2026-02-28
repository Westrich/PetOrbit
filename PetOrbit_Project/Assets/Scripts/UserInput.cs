using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public CamMoveTo camControll;
    public PetSpawner spawner;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        camControll = Camera.main.GetComponent<CamMoveTo>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard.anyKey.wasPressedThisFrame||keyboard.anyKey.isPressed)
        {
            if (keyboard.pKey.wasPressedThisFrame)
            {
               // Debug.Log("pressed p");
                spawner.SpawnMultiplePets(6);
                
            }
            else if (keyboard.aKey.wasPressedThisFrame)
            {
               // Debug.Log("pressed a");
                camControll.PreviousCrate();
            }
            else if (keyboard.dKey.wasPressedThisFrame)
            {
                //Debug.Log("pressed d");
                camControll.NextCrate();
            }

           
        }
    }

    

   
}
