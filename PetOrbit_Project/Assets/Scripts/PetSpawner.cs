using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using System;

public class PetSpawner : MonoBehaviour
{
    
    public List<Crate> crates;
    [SerializeField] private List<PetData> possiblePets = new List<PetData>();
    [SerializeField] private List<ColorData> possibleColorCombos = new List<ColorData>();
    [SerializeField] private ColorList colorList;
    [SerializeField] private GameObject petPrefab;
    public GameObject PetPrefab => petPrefab;
    /*[SerializeField] private GameObject petPrefab;
    [SerializeField] private List<Pet> generatedPets = new List<Pet>();
    [SerializeField] private Pet latestPet;
    [SerializeField] private ColorData currentColor;
    [SerializeField] private List<Vector3> spawnPositions = new List<Vector3>();
    [SerializeField] private List<Crate> crates;
    [SerializeField] private bool maxPetsSpawned= false;
    [SerializeField] private CrateManager _crateManager;
    public int spawnamount = 1;*/
    
    public static PetSpawner Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    private void OnValidate()
    {
        if (possibleColorCombos.Count==0&&colorList)
        {
            foreach (var colorData in colorList.colorLists)
            {
                possibleColorCombos.Add(colorData);
            }
        }
    }

    private void AssignCrates()
    {
        var randomPet =  Random.Range(0, possiblePets.Count);
        foreach (var crate in crates)
        {
            crate.SetPet(possiblePets[randomPet]);
            var previousPet = randomPet;
            while (previousPet == randomPet)
            {
                randomPet = Random.Range(0, possiblePets.Count);
            }
        }
    }

    public void SpawnMultiplePets(int amount)
    {
        AssignCrates();
    }

    /*
    private void SetColor()
    {
        MeshRenderer[] renderers = latestPet.GetComponentsInChildren<MeshRenderer>();


        foreach (var rend in renderers)
        {
            latestPet.petData.SetColor("colorA",currentColor.GetColor(1));
            latestPet.petData.SetColor("colorB",currentColor.GetColor(0));
            rend.material.SetColor("_Color_A", latestPet.petData.GetColor("colorA"));
            rend.material.SetColor("_Color_B",latestPet.petData.GetColor("colorB"));
        }
    }

    private void PickColor()
    {
        ColorData colorCombo;
        int index;
        index = Random.Range(0,possibleColorCombos.Count);
        colorCombo = possibleColorCombos[index];
        currentColor = colorCombo;
    }

  

    }*/
}
