using UnityEditor.Timeline;
using UnityEngine;

public class SittingState : PetState
{
    public SittingState(PetController petController, PetStateMachine.EPetState stateID) : base(petController, stateID)
    {
        PetController = petController;
    }

    private bool _rested = false;

    #region MustImpliment

        public override void EnterState()
        {
            Debug.Log("Enter Sitting State");
            PetController.Agent.destination = PetController.Pet.GetPosition();
        }

        public override void UpdateState()
        {
            while (PetController.Pet.Condition.Rest<10)
            {
                Rest();
            }
        }

        public override void ExitState()
        {
            Debug.Log("Exit Sitting State");
        }

        public override PetStateMachine.EPetState GetNextState()
        {
           // if (_rested) return PetStateMachine.EPetState.Roaming;
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

    private void Rest()
    {
        if (PetController.Pet.Condition.Rest < 10)
        {
            _rested = false;
        }
        else
        {
            _rested = true;
            return;
        }
        
        PetController.Pet.Condition.Rest += 1*Time.deltaTime;
        
    }
}
