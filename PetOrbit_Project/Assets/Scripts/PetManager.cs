using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{

    public List<Pet> allPets = new List<Pet>();
    public List<Pet_SO> allPetData = new List<Pet_SO>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void SafePetData(Pet pet, Pet_SO petData)
    {
        allPets.Add(pet);
        allPetData.Add(petData);
    }

    private void DeletePet(Pet pet,Pet_SO petData)
    {
        allPets.Remove(pet);
        allPetData.Remove(petData);
    }
}
