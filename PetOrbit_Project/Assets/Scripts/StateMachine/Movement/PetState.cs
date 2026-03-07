using UnityEngine;

public abstract class PetState : BaseState<PetStateMachine.EPetState>
{
    protected PetController PetController;
    
    public PetState(PetController petController,PetStateMachine.EPetState stateID) : base(stateID)
    {
        PetController = petController;
    }
 
   
   
}
public struct Stat
{
    public Stat(string name, float statValue)
    {
        StatName = name;
        Test = 0f;
         _statValue = statValue;
        _depletionRate = 1f;
        _replenishRate = 1f;
    }
    public Stat(string name, float statValue, float depletionRate)
    {
        StatName = name;
        Test = 0f;
        _statValue = statValue;
        _depletionRate = depletionRate;
        _replenishRate = 1f;
    }
    public Stat(string name)
    {
        StatName = name;
        Test = 0f;
        _statValue = 0f;
        _depletionRate = 1f;
        _replenishRate = 1f;
    }
        
    private string StatName{ get; set; }
    private float _statValue { get; set; }
    public float StatValue => _statValue;
    private float _depletionRate { get; set; }
    public float DepletionRate => _depletionRate;
    private float _replenishRate { get; set; }
    public float ReplenishRate => _replenishRate;
    
    public float Test { get; set; }

    public string GetName()
    {
        return StatName;
    }

    public void SetValue(float newValue)
    {
        _statValue += newValue;
       
    }

    public void SetDepletionRate(float newRate)
    {
        _depletionRate = newRate;
    }
    
    public void SetReplenishRate(float newRate)
    {
        _replenishRate = newRate;
    }
}