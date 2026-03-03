using UnityEngine;

public class NeedsStatemachine : StateMachine<NeedsStatemachine.ENeedState>
{
    public enum ENeedState
    {
        Hungry,
        Thirsty,
        Sleepy,
        Cuddly,
        Clean,
        Content
        
    }
    
    private float _timeLastPet;
    private float _timeLastFed;
    private float _timeLastDrink;
    private float _timeLastWashed;

    private NeedContext _context;
    [SerializeField] private Pet pet;
    
    private void Awake()
    {
        _context =  gameObject.GetComponent<NeedContext>().Create(_timeLastPet,_timeLastFed,_timeLastDrink,_timeLastWashed,pet);
        InitializeStates();
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
    }
    
    protected override void InitializeStates()
    {
        //Add states to inherited StateMachine "States" dictionary and Set Initial State
        States.Add(ENeedState.Hungry, new HungryState(_context,ENeedState.Hungry));
        States.Add(ENeedState.Thirsty, new ThirstyState(_context,ENeedState.Thirsty));
        States.Add(ENeedState.Sleepy, new SleepyState(_context,ENeedState.Sleepy));
        States.Add(ENeedState.Cuddly, new CuddlyState(_context,ENeedState.Cuddly));
        States.Add(ENeedState.Clean, new CleanState(_context,ENeedState.Clean));
        States.Add(ENeedState.Content, new ThirstyState(_context,ENeedState.Content));
        CurrentState = States[ENeedState.Content];
    }
}
