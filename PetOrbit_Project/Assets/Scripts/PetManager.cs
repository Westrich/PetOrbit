using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{

    public List<Pet> allPets = new List<Pet>();
    public List<PetData> allPetData = new List<PetData>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void SafePetData(Pet pet, PetData petData)
    {
        allPets.Add(pet);
        allPetData.Add(petData);
    }

    private void DeletePet(Pet pet,PetData petData)
    {
        allPets.Remove(pet);
        allPetData.Remove(petData);
    }
}
