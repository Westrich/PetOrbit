using UnityEngine;

public class NeedContext : MonoBehaviour
{
   private float _timeLastPet;
   private float _timeLastFed;
   private float _timeLastDrink;
   private float _timeLastWashed;

   public NeedContext Create(float timeLastPet,float timeLastFed, float timeLastDrink, float timeLastWashed, Pet pet)
   {
      _timeLastPet = timeLastPet;
      _timeLastFed = timeLastFed;
      _timeLastDrink = timeLastDrink;
      _timeLastWashed = timeLastWashed;
      return this;
   }
}
