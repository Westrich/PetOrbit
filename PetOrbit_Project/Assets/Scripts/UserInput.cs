using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public CamMoveTo camControll;
    public PetSpawner spawner;
    public int crateColum = 1;
    public int crateRow = 0;
    
    
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
            else if (keyboard.rKey.wasPressedThisFrame)
            {
               // Debug.Log("pressed r");
                //spawner.ResetPets();
               
            }
            else if (keyboard.wKey.wasPressedThisFrame)
            {
                //Debug.Log("pressed w");
                if (crateRow == 0) crateRow = 1;
            }
            else if (keyboard.sKey.wasPressedThisFrame)
            {
               // Debug.Log("pressed s");
                if (crateRow == 1) crateRow = 0;
            }
            else if (keyboard.aKey.wasPressedThisFrame)
            {
               // Debug.Log("pressed a");
                if (crateColum != 0) crateColum -= 1;
            }
            else if (keyboard.dKey.wasPressedThisFrame)
            {
                //Debug.Log("pressed d");
                if (crateColum != 2) crateColum += 1;
            }
/*
            if (camControll == null)
            {
                camControll = Camera.main.GetComponent<CamMoveTo>();
            }
            camControll.ChangeCrate(crateRow,crateColum);
            */
        }
    }

    private void FixedUpdate()
    {
       
    }

   
}
