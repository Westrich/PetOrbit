using UnityEngine;

public class Item : MonoBehaviour
{

  protected string ItemName;

  protected virtual void Create(Item item)
  {
    ItemName = item.ItemName;

  }
  protected virtual void Use()
  {
    
  }
  
  protected virtual void Use(float amount)
  {
    
  }
  
  protected virtual void ResetItem()
  {
    
  }
}
