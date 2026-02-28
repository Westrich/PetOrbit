using UnityEngine;

public class Crate : MonoBehaviour
{
  [SerializeField] private Light light;
  [SerializeField] private Pet petInCrate;
  [SerializeField] private Transform petSpawnPoint;

  public void SetPet(PetData petData)
  {
    if(petInCrate != null) ResetPet();
    petInCrate = Instantiate(PetSpawner.Instance.PetPrefab, transform).GetComponent<Pet>();
    petInCrate.CreatePet(petData);
  }

  private void ResetPet()
  {
    Destroy(petInCrate.gameObject);
  }

  public Pet GetPet()
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
