using UnityEngine;

public abstract class MovementState : BaseState<MovementMachine.EMoveState>
{
    protected MovementContext Context;
   
    public MovementState(MovementContext context,MovementMachine.EMoveState stateID) : base(stateID)
    {
        Context = context;
    }
}
