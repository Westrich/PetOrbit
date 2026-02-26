using UnityEngine;

public class Crate : MonoBehaviour
{
  [SerializeField] private Light light;
  [SerializeField] private GameObject petInCrate;

  public void SetPet(Pet pet)
  {
    petInCrate = pet.gameObject;
  }

  public GameObject GetPet()
  {
    return petInCrate;
  }
  
  public void BrightenLight()
  {
    light.intensity *= 10;
  }
  
  public void DimLight()
  {
    light.intensity /= 10;
  }
}
