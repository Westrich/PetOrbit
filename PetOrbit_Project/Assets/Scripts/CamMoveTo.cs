using System.Collections.Generic;
using NUnit.Framework;
using Unity.Cinemachine;
using UnityEngine;

public class CamMoveTo : MonoBehaviour
{
    public List<CameraTarget> cratePositions;
    public CinemachineCamera cinemachine;
    public int TargetIndex=0;
    
    public void NextCrate()
    {
        if (TargetIndex!= cratePositions.Count-1)
        {
            TargetIndex += 1;
        }
        else TargetIndex = 0;
       
        cinemachine.Target = cratePositions[TargetIndex];

    }

    public void PreviousCrate()
    {
        if (TargetIndex != 0)
        {
            TargetIndex -= 1;
        }
        else TargetIndex = cratePositions.Count - 1;
        cinemachine.Target = cratePositions[TargetIndex];
    }
}
