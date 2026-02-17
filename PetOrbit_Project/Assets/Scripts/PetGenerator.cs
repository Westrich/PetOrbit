using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class PetGenerator : MonoBehaviour
{
   [SerializeField] private List<Pet_SO> possiblePet = new List<Pet_SO>();
   [SerializeField] private GameObject petPrefab;
   [SerializeField] private List<Pet> _allPets = new List<Pet>();
   private Pet _pet;
   private GameObject pet;
   private Vector3 SpawnPosition = new Vector3(0, 0.1f, 1.5f);
   private int PetsSpawned = 0;
   public Color[] colors=new Color[3];


   private void Awake()
   {
      colors = new Color[3];
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.P)&& PetsSpawned<=2)
      {
         switch (PetsSpawned)
         {
            case 0 :
            {
               SpawnPosition.x = -0.5f;
               break;
            }
            case 1 :
            {
               SpawnPosition.x = 0.5f;
               break;
            }
            case 2 :
            {
               SpawnPosition.x = 1.5f;
               break;
            }
            
         }
         SpawnNewPet(SpawnPosition, Quaternion.Euler(0, 0, 0));
      }
      if (Input.GetKeyDown(KeyCode.R))
      {
        //Debug.Log("pushin R");
         foreach (var byepet in _allPets)
         {
            Destroy(byepet.gameObject);
         }
         _allPets.Clear();
         PetsSpawned = 0;
      }
   }


   public void SpawnNewPet(Vector3 position, Quaternion rotation)
   {
      for (int i = 0; i <3; i++)
      {
         switch (PetsSpawned)
         {
            case 0 :
            {
               SpawnPosition.x = -0.5f;
               break;
            }
            case 1 :
            {
               SpawnPosition.x = 0.5f;
               break;
            }
            case 2 :
            {
               SpawnPosition.x = 1.5f;
               break;
            }
            
         }
         PetsSpawned += 1;
         //Debug.Log("SpawnPet Called");
         MakePet(pet);
         SetMaterial(pet);
         Place(SpawnPosition,rotation);
      }

   }

   private void Place(Vector3 position, Quaternion rotation)
   {
      pet.transform.position = position;
      pet.transform.rotation = rotation;
   }
   private void MakePet(GameObject petObj)
   {
      pet = Instantiate(petPrefab);
      _pet = pet.GetComponent<Pet>();
      _pet.petData = InstancePetData();
      _allPets.Add(_pet);
      MakeMesh(pet);
      //Debug.Log("pet data chosen from "+_pet.petData);
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
         
         colors[1] = new Color(RandomRGBvalue(0,2), RandomRGBvalue(0,1), RandomRGBvalue(0,2));
         //colors[0] = new Color(RandomRGBvalue(), RandomRGBvalue(), RandomRGBvalue());
         colors[0] = new Color(colors[1].r*RandomRGBvalue(.5f,2f),colors[1].g*RandomRGBvalue(.5f,1f), colors[1].b*RandomRGBvalue(.5f,2f));
         colors[2] = new Color(0, 0, 0);

      }
      
      private float RandomRGBvalue(float a, float b)
      {
         float value;
         uint seed = 1;
         Unity.Mathematics.Random rng = new Unity.Mathematics.Random(seed);
         value = rng.NextFloat();
         value = Random.Range(a,b);
         //Debug.Log("random number got " + value);
         return value;
      }
      private void MakeMesh(GameObject pet)
      {
         pet = Instantiate(_pet.GetModel(),pet.transform);
         //pet.GetComponentInChildren<MeshRenderer>().material = _pet.GetMaterial();
         
      }
   #endregion
}
