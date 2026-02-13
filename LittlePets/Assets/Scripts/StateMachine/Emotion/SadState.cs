using UnityEngine;

public class SadState : EmotionState
{ 
    public SadState(EmotionContext context, EmotionStateMachine.EEmotionState stateID) : base(context, stateID)
    {
        EmotionContext Context = context;
        
    }
    
    public GameObject obj;

    public override void EnterState()
    {
         obj = Context.testObject;
         ChangeMaterial(obj,2,obj.GetComponent<ChangeMaterial>());
        Debug.Log("Entering Sad State");
    }

    public override void UpdateState()
    {
        // Debug.Log("Updating Sad State");
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Sad State");
    }

    public override EmotionStateMachine.EEmotionState GetNextState()
    {
        //returns the stateID to its parent EmotionState which in turn returns it to its own parent baseState
        //throw new System.NotImplementedException();
        Debug.Log(StateID);
        return StateID;
    }

    #region TriggerMethods

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
