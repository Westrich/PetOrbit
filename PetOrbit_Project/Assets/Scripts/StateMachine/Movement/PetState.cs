using UnityEngine;

public abstract class PetState : BaseState<PetStateMachine.EPetState>
{
    protected PetController PetController;
   
    public PetState(PetController petController,PetStateMachine.EPetState stateID) : base(stateID)
    {
        PetController = petController;
    }
}
