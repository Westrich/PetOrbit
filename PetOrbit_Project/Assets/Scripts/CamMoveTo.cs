using System.Collections.Generic;
using NUnit.Framework;
using Unity.Cinemachine;
using UnityEngine;

public class CamMoveTo : MonoBehaviour
{
    public List<CameraTarget> cratePositions;

    public int currenttarget = 1;
    public CinemachineCamera cinemachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeTarget(0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeTarget(1);
        }
    }

    public void ChangeTarget(int input)
    {
        if (input == 0)
        {
            if (currenttarget!=0)
            {
                currenttarget -= 1;
                cinemachine.Target = cratePositions[currenttarget];
            }else return;
        }else if (input == 1)
        {
            if (currenttarget != 2)
            {
                currenttarget += 1;
                cinemachine.Target = cratePositions[currenttarget];
            }
            
        }
    }
}
