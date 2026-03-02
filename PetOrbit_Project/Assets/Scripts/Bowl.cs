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
      Vector3 position = bowlContents.transform.localPosition;
      position.y = MinMaxPosition.y;
      bowlContents.transform.localPosition = position;
      base.ResetItem();
   }

   protected override void AdjustVisuals()
   {
      Vector3 position = bowlContents.transform.localPosition;
      position.y =Mathf.Lerp(MinMaxPosition.x, MinMaxPosition.y, (amountLeft/100f));
      bowlContents.transform.localPosition = position;
      base.AdjustVisuals();
      
   }
}
