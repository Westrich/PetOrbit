using System;
using UnityEngine;

public class Bowl : Consumable
{
   [SerializeField] private GameObject bowlContents;
   [SerializeField] private Vector2 MinMaxPosition;
   private void Awake()
   {
      base.Create(this);
   }

   protected override void ResetItem()
   {
      amountLeft = 100;
      Vector3 position = bowlContents.transform.position;
      position.y = MinMaxPosition.y;
      bowlContents.transform.position = position;
      base.ResetItem();
   }

   protected override void AdjustVisuals()
   {
      Vector3 position = bowlContents.transform.position;
      position.y =Mathf.Lerp(MinMaxPosition.x, MinMaxPosition.y, (amountLeft/100f));
      bowlContents.transform.position = position;
      base.AdjustVisuals();
      
   }
}
