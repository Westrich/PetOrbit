using System;
using UnityEngine;

public class Pet : MonoBehaviour
{
    private PetData _petData;
    private GameObject _petBody;
    public PetData PetData => _petData;
    public PetData defaultPetData;

    private void Start()
    {
        if(_petData == null) CreatePet(defaultPetData);
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
