using System;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public Pet(Pet_SO PetData)
    {
        petData = PetData;
    }
    public GameObject model;
    public Pet_SO petData;

    private void Awake()
    {
        
    }

    private void SpawnPet()
    {
        
    }

    public Material GetMaterial()
    {
        Material material = model.GetComponentInChildren<MeshRenderer>().sharedMaterial;
        var mat = new Material(material);
        return mat;
    }
    public GameObject GetModel()
    {
        model = petData.GetSpecies().modelPrefab;
        return model;
    }

}
