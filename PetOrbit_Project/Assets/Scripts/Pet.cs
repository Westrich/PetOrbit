using System;
using UnityEngine;

public class Pet : MonoBehaviour
{
    //Spawn data
    private PetData _petData;
    private GameObject _petBody;
    public PetData PetData => _petData;
    public PetData defaultPetData;
    
    // Pets Needs
    public float hunger = 0f;
    public float thirst = 0f;
    public float sleepiness = 0f;

    private void Start()
    {
        if(_petData == null) CreatePet(defaultPetData);
    }

    private void Eat()
    {
        hunger = 0f;
    }

    private void Drink()
    {
        thirst = 0f;
    }

    private void Sleep()
    {
        sleepiness = 0f;
    }

    public void CreatePet(PetData petData)
    {
        _petData = petData;
        CreateBody();
    }

    private void CreateBody()
    {
        Debug.Log(_petData.SpeciesSo.modelPrefab.name);
        var body = Instantiate(_petData.SpeciesSo.modelPrefab, transform);
        _petBody = body;
        
        MeshRenderer[] renderers = _petBody.GetComponentsInChildren<MeshRenderer>();

        foreach (var rend in renderers)
        {
            rend.material.SetColor("_Color_A", _petData.GetColor("colorA"));
            rend.material.SetColor("_Color_B",_petData.GetColor("colorB"));
        }
    }

    public Material GetMaterial()
    {
        Material material = _petBody.GetComponentInChildren<MeshRenderer>().sharedMaterial;
        var mat = new Material(material);
        return mat;
    }
    public GameObject GetModel()
    {
        return _petData.SpeciesSo.modelPrefab;
    }

}
