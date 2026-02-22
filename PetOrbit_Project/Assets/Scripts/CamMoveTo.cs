using System.Collections.Generic;
using NUnit.Framework;
using Unity.Cinemachine;
using UnityEngine;

public class CamMoveTo : MonoBehaviour
{
    public List<CameraTarget> cratePositions;

    public int crateColum = 1;
    public int crateRow = 0;
    public CinemachineCamera cinemachine;
    
    public void ChangeCrate(int row, int colum)
    {
        if (row == 0)
        {
            cinemachine.Target = cratePositions[colum];
        }
        if (row == 1)
        {
            cinemachine.Target = cratePositions[colum+3];
        }
        
        
    }
}
