using UnityEngine;

public class MovementMachine : StateMachine<MovementMachine.EMoveState>
{
    public enum EMoveState
    {
        Roaming,
        Sleeping,
        Eating,
        Cuddling,
        Sitting,
        Fetching,
        
    }

    private MovementContext _context;

    protected override void InitializeStates()
    {
        throw new System.NotImplementedException();
    }
}
