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
    [SerializeField] private GameObject petPrefab;
    [SerializeField] private ColorList colorList;
    [SerializeField] private List<ColorData> possibleColorCombos = new List<ColorData>();
    [SerializeField] private ColorData currentColor;
    public GameObject PetPrefab => petPrefab;
    // Create Singleton
    public static PetSpawner Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null) Destroy(gameObject);
        else Instance = this;
        AssignCrates();
    }

    private void OnValidate()
    {
        // Copy over the color combos from Color list
        if (possibleColorCombos.Count==0&&colorList)
        {
            CopyColorCombos();
        }
    }

    private void CopyColorCombos()
    {
        // Copy over the color combos from Color list
        foreach (var combo in colorList.colorLists)
        {
            possibleColorCombos.Add(combo);
        }
    }
    private void AssignCrates()
    {
        var randomPet =  Random.Range(0, possiblePets.Count);
       
       
        foreach (var crate in crates)
        {
            PickColor();
            var petdata = Instantiate(possiblePets[randomPet]);
            petdata.SetColor("colorA",currentColor.GetColor(1));
            petdata.SetColor("colorB",currentColor.GetColor(0));
            crate.SetPet(petdata);
             var previousPet = randomPet;
            // Making sure it is never the same species twice
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

    

    private void PickColor()
    {
        ColorData colorCombo;
        int index;
        index = Random.Range(0,possibleColorCombos.Count);
        colorCombo = possibleColorCombos[index];
        currentColor = colorCombo;
    }

  

    
}
