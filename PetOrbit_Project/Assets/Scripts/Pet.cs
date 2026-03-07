using System;
using UnityEngine;
using UnityEngine.AI;

public class Pet : MonoBehaviour
{
    //Spawn data
    private PetData _petData;
    public PetData defaultPetData;
    public PetData PetData => _petData;
    private GameObject _petBody;
    
    // Movement
    private PetController _controller;
    public PetController Controller => _controller;
    
    // Feelings of Pet
    public Condition _condition = new Condition(0,0,0,0);
    public Condition Condition => _condition;

    // Colors
    private static readonly int ColorA = Shader.PropertyToID("_Color_A");
    private static readonly int ColorB = Shader.PropertyToID("_Color_B");


    private void Start()
    {
        if(_petData == null) CreatePet(defaultPetData);
        _controller = GetComponent<PetController>();
        _condition.ResetCondition();
        _condition.Exhaustion.SetReplenishRate(20);
        _condition.Exhaustion.SetDepletionRate(20);
    }

   

    // Constructor
    
    public void CreatePet(PetData petData)
    {
        _petData = petData;
        defaultPetData = _petData ;
        CreateBody();
    }
    
    // Instantiate body prefab of pets species
    
    private void CreateBody()
    {
        
        var body = Instantiate(_petData.SpeciesSo.modelPrefab, transform);
        _petBody = body;
        
        MeshRenderer[] renderers = _petBody.GetComponentsInChildren<MeshRenderer>();

        foreach (var rend in renderers)
        {
            rend.material.SetColor(ColorA, _petData.GetColor("colorA"));
            rend.material.SetColor(ColorB,_petData.GetColor("colorB"));
        }
    }

    // Returns Pet Material
    
    public Material GetMaterial()
    {
        Material material = _petBody.GetComponentInChildren<MeshRenderer>().sharedMaterial;
        var mat = new Material(material);
        return mat;
    }
    
    // Returns the prefab Species Model of the pet data
    
    public GameObject GetModel()
    {
        return _petData.SpeciesSo.modelPrefab;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void AssignColors(Color a, Color b)
    {
        _petData.SetColor("colorA",a);
        _petData.SetColor("colorB",b);
    }

}





