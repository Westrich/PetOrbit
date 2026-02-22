using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PetSpawner : MonoBehaviour
{
    [SerializeField] private List<Pet_SO> possiblePet = new List<Pet_SO>();
    [SerializeField] private List<Color_SO> possibleColorCombos = new List<Color_SO>();
    [SerializeField] private GameObject petPrefab;
    [SerializeField] private List<Pet> generatedPets = new List<Pet>();
    [SerializeField] private Pet latestPet;
    [SerializeField] private Color_SO currentColor;
    [SerializeField] private List<Vector3> spawnPositions = new List<Vector3>();
    [SerializeField] private bool maxPetsSpawned= false;
   

    private void Awake()
    {
        
    }

    public void SpawnMultiplePets(int amount)
    {
        if (maxPetsSpawned)
        {
            Debug.Log("maximum amount of pets spawned");
            return;
        }
        PopulatePositions(amount);
        for (int i = 0; i < amount; i++)
        {
            Debug.Log(i);
            SpawnPet(spawnPositions[i]);
        }

        foreach (var pet in generatedPets)
        {
            Debug.Log(pet.petData.GetName());
        }

        maxPetsSpawned = true;
    }

    private void SpawnPet(Vector3 position)
    {
        Debug.Log(position.x);
        CreatePet();
        PickColor();
        SetColor();
        Place(position, Quaternion.Euler(0,0,0));
    }

    public void ResetPets()
    {
        foreach (var byepet in generatedPets)
        {
            Destroy(byepet.gameObject);
        }
        spawnPositions.Clear();
        generatedPets.Clear();
        maxPetsSpawned = false;
    }

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
        Color_SO colorCombo;
        int index;
        index = Random.Range(0,possibleColorCombos.Count);
        colorCombo = possibleColorCombos[index];
        currentColor = colorCombo;
    }
    
    private void PopulatePositions(int amount)
    {
        Debug.Log("Populateposition funtion enter");
        float row = 0;
        int colum = 0;
        for (int i = 0; i < amount; i++)
        {
            if (i % 2 == 0)
            {
                row = 1.055f;
            }
            else
            {
                row = 0;
            }

            if (i < amount/2)
            {
                colum = i;
            }
            else
            {
                colum = i - amount / 2;
            }
            spawnPositions.Add(new Vector3(ColumToPos(colum),row+0.125f,1.5f));
           Debug.Log("Colum Position " + ColumToPos(colum) + "row position" + row);
            
        }
        Debug.Log("Populateposition funtion exit");
    }

    private float ColumToPos(int colum)
    {
        return colum - 0.5f;
    }
    private void Place(Vector3 position, Quaternion rotation)
    {
        latestPet.transform.position = position;
        latestPet.transform.rotation = rotation;
    }
    
    private void CreatePet()
    {
        var petContainer = Instantiate(petPrefab);
        var pet = petContainer.GetComponent<Pet>();
        pet.petData = SelectRandomPet();
        generatedPets.Add(pet);
        latestPet = pet;
        
        //instantiate mesh
        Instantiate(pet.GetModel(),pet.transform);

    }

    private Pet_SO SelectRandomPet()
    {
        if (possiblePet == null)
        {
            Debug.Log("List of possible pets is null");
            return null;
        }
        if (possiblePet.Count==0)
        {
            Debug.Log("List of possible pets is empty");
            throw new NotImplementedException();
        }
        else
        {
            Debug.Log(possiblePet.Count);
            int value;
            value = Random.Range(0,possiblePet.Count);
            return possiblePet[value];
        }
      
    }
}
