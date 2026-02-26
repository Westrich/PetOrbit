using System.Collections.Generic;
using UnityEngine;
using System;

public class CrateManager : MonoBehaviour
{
    [SerializeField] private Crate currentCrate;
    public List<Crate> allCrates = new List<Crate>();
    public GameObject petInCurrentCrate;
    public string nameOfPet;


    private void Awake()
    {
        if (currentCrate != null)
        {
            currentCrate.BrightenLight();
        }
    }

    public List<Crate> GetCrates()
    {
        return allCrates;
    }

    public void FocusOnCrate(int index)
    {
        Debug.Log("focusing on"+allCrates[index]);
        if (currentCrate != null)
        {
            currentCrate.DimLight();
        }
        currentCrate = allCrates[index];
       
        petInCurrentCrate = allCrates[index].GetPet();
        if (petInCurrentCrate != null)
        {
            nameOfPet = petInCurrentCrate.GetComponent<Pet>().petData.GetName();
        }
        currentCrate.BrightenLight();
    }

    public void ClearCrates()
    {
        foreach (var crate in allCrates)
        {
            crate.SetPet(null);
        }
    }
    
    public void FillCrate(Crate crate, Pet pet)
    {
        crate.SetPet(pet);
    }

    
}
