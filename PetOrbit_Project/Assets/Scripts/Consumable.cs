using System;
using UnityEngine;

public class Consumable : Item
{
    [SerializeField] protected string Itemname;
    [SerializeField] protected float _maxAmount = 0f;
    [SerializeField] protected float _currentAmount = 0f;
    [SerializeField] protected bool _consumed  = false;
    [SerializeField] protected ConsumableData _consumabledata;
    [SerializeField] protected float amountLeft;
    [SerializeField] protected Consumable _consumable;
    //Testing properties for editor
    public bool takeBite = false;
    public bool reset = false;
    public float biteSize = 1f;

    private void Update()
    {
        if (takeBite && !_consumed)
        {
            takeBite = false;
            Consume(biteSize);
            
        }
        if (reset)
        {
            reset = false;
            ResetItem();
        }
    }

    protected void Create(Consumable consumable)
    {
        _consumable = consumable;
        _maxAmount = _consumabledata.GetMaxAmt();
        _consumable.ResetItem();
        Itemname = _consumabledata.GetName();
        ItemName = Itemname;
        base.Create(this);
    }

    protected override void ResetItem()
    {
         amountLeft = 100f;
        _currentAmount = _maxAmount;
        _consumed = false;
    }

    protected virtual float Consume(float amount)
    {
        float amountConsumed=_currentAmount;
        
        _currentAmount -= amount;
        if (_currentAmount<=0)
        {
            _currentAmount = 0;
            _consumed = true;
            amountLeft = 0f;
            AdjustVisuals();
            return amountConsumed;
        }
        else
        {
            amountLeft = (100/ _maxAmount ) * _currentAmount;
            AdjustVisuals();
            return amount;
        }
        
    }

    protected virtual void AdjustVisuals()
    {
        
    }
    protected override void Use(float amount)
    {
       Consume(amount);
    }
}
