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
    private Condition _condition = new Condition();
    public Condition Condition => _condition;

    // Colors
    private static readonly int ColorA = Shader.PropertyToID("_Color_A");
    private static readonly int ColorB = Shader.PropertyToID("_Color_B");


    private void Start()
    {
        if(_petData == null) CreatePet(defaultPetData);
        _controller = GetComponent<PetController>();
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



public class Condition
{
    public float Hunger ;
    public float Thirst ;
    public float Sleepiness ;
    public float Rest;
    
    public Condition(float hunger, float thirst, float sleepiness,float rest)
    {
        Hunger = hunger;
        Thirst = thirst;
        Sleepiness = sleepiness;
        Rest = rest;
    }
    
    public Condition()
    {
        Hunger = 0;
        Thirst = 0;
        Sleepiness = 0;
        Rest = 10;
    }

    
    
    public void ResetCondition()
    {
        Hunger = 0;
        Thirst = 0;
        Sleepiness = 0;
    }

    public void BadCondition()
    {
        Hunger = 100;
        Thirst = 100;
        Sleepiness = 100;
    }

    public void Eat(float amount)
    {
        Hunger -= amount;
    }

    public void Drink(float amount)
    {
        Thirst -= amount;
    }

    public void Sleep(float amount)
    {
        Sleepiness -= amount;
    }

    public void GetHungry(float amount)
    {
        Hunger += amount;
    }

    public void GetThirsty(float amount)
    {
        Thirst += amount;
    }

    public void Fatigue(float amount)
    {
        Sleepiness += amount;
    }

}


