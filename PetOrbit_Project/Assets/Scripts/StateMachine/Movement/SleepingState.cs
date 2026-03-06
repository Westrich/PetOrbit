using UnityEditor.Timeline;
using UnityEngine;

public class SleepingState : PetState
{
    public SleepingState(PetController petController, PetStateMachine.EPetState stateID) : base(petController, stateID)
    {
        PetController = petController;
    }

    #region MustImpliment

        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateState()
        {
           
        }

        public override void ExitState()
        {
            
        }

        public override PetStateMachine.EPetState GetNextState()
        {
            return StateID;
        }

        public override void OnTriggerEnter(Collider other)
        {
            
        }

        public override void OnTriggerStay(Collider other)
        {
            
        }

        public override void OnTriggerExit(Collider other)
        {
           
        }
    #endregion
}
