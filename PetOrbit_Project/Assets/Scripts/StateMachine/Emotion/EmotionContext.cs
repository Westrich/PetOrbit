using UnityEngine;

public class EmotionContext : MonoBehaviour
{
    #region Explaination

    /*
     if there are values in the statemachine that need to be stored and accessed defnine them in the statemachine
     copy them over here and put them in the constructor of the context like so 
     
     private float _contentness;
     private float _timelastpet;
     
     public EmotionContext(float contentness,float timelastpet)      <-This is the constructor
     {
          _contentness=contentness;
          _timelastpet=timelastpet;
     }
    */

  #endregion

  public GameObject testObject;

  public EmotionContext(GameObject obj)
  {
      testObject = obj;
  }
  
  //Nothing is in here yet because i have no logic yet in my game but a rough example is here aswell
  
}
