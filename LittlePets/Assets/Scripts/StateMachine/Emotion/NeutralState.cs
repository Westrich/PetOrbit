using UnityEngine;

public class NeutralState : EmotionState
{ 
    public NeutralState(EmotionContext context, EmotionStateMachine.EEmotionState stateID) : base(context, stateID)
    {
        EmotionContext Context = context;
       
    }

    public GameObject obj;

    
    public override void EnterState()
    {
        obj = Context.testObject;
        Debug.Log("Entering Neutral State");
        ChangeMaterial(obj,0,obj.GetComponent<ChangeMaterial>());
        
    }

    public override void UpdateState()
    {
        // Debug.Log("Updating Neutral State");
       
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Neutral State");
    }

    public override EmotionStateMachine.EEmotionState GetNextState()
    {
        //returns the stateID to its parent EmotionState which in turn returns it to its own parent baseState
      
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
