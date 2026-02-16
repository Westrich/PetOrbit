using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PetGenerator : MonoBehaviour
{
   public Color[] colors=new Color[3];
   [SerializeField] private List<Pet_SO> possiblePet = new List<Pet_SO>();
   private Pet _pet;
   private GameObject pet;
   [SerializeField] private GameObject petPrefab;
   [SerializeField] private List<Pet> _allPets = new List<Pet>();
   private Vector3 SpawnPosition = new Vector3(0, 0, 0);
   private int PetsSpawned = 0;


   private void Awake()
   {
      colors = new Color[3];
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.P))
      {
         Debug.Log("P pressed");
         SpawnNewPet(new Vector3(PetsSpawned/2f, 0, 0), Quaternion.Euler(0, 0, 0));
      }
   }


   public void SpawnNewPet(Vector3 position, Quaternion rotation)
   {
      PetsSpawned += 1;
      Debug.Log("SpawnPet Called");
     MakePet(pet);
     SetMaterial(pet);
     Place(position,rotation);

   }

   private void Place(Vector3 position, Quaternion rotation)
   {
      Debug.Log("Place called at " + position +rotation);
      pet.transform.position = position;
      pet.transform.rotation = rotation;
   }
   private void MakePet(GameObject petObj)
   {
      Debug.Log("make pet called ");
       pet = Instantiate(petPrefab);
      _pet = pet.GetComponent<Pet>();
      _pet.petData = InstancePetData();
      _allPets.Add(_pet);
      MakeMesh(pet);
      Debug.Log("pet data chosen from "+_pet.petData);
   }
   
   private void SetMaterial(GameObject pet)
   {
      MeshRenderer[] renderers = pet.GetComponentsInChildren<MeshRenderer>();
      Material mat =  _pet.GetMaterial();;
      GenerateColors();
      foreach (var rend in renderers)
      {
         rend.material.SetColor("_Color_B", colors[1]);
         rend.material.SetColor("_Color_A",colors[0]);
         rend.material.SetColor("_Color_C",colors[2]);
      }

   }
   
   //Helper Functions

   #region Helpers
   private Pet_SO InstancePetData()
      {
          
         var petSo = Instantiate(possiblePet[GetRandPetIndex()]);
         return petSo;
         
      }

      private int GetRandPetIndex()
      {
         int listlength;
         int index;
         listlength = possiblePet.Count;
         index = Random.Range(0, listlength);
         return index;
      }
      private void GenerateColors()
      {
         Debug.Log("old colors" +colors[0] + colors[1]);
         colors[1] = new Color(RandomRGBvalue(), RandomRGBvalue(), RandomRGBvalue());
         colors[0] = new Color(RandomRGBvalue(), RandomRGBvalue(), RandomRGBvalue());
         colors[2] = new Color(0, 0, 0);
         
         
         Debug.Log("new colors" +colors[0] + colors[1]);
         
      }
      
      private float RandomRGBvalue()
      {
         float value;
         uint seed = 1;
         Unity.Mathematics.Random rng = new Unity.Mathematics.Random(seed);
         value = rng.NextFloat();
         value = Random.Range(0f,2f);
         //Debug.Log("random number got " + value);
         return value;
      }
      private void MakeMesh(GameObject pet)
      {
         pet = Instantiate(_pet.GetModel(),pet.transform);
         //pet.GetComponentInChildren<MeshRenderer>().material = _pet.GetMaterial();
         Debug.Log("mesh renderer form " + pet + " found. Color A is "
                   +pet.GetComponentInChildren<MeshRenderer>().material.GetColor("_Color_A") 
                   +pet.GetComponentInChildren<MeshRenderer>().material.GetColor("_Color_A") );
         
      }
   #endregion
}
