using System;
using UnityEngine;

public class EmotionStateMachine : StateMachine<EmotionStateMachine.EEmotionState>
{ 
   public enum EEmotionState
   {
      Happy,
      Neutral,
      Sad,
   }
   private EmotionContext _context;
   public GameObject myobject;

   private void Awake()
   {
      _context = new EmotionContext(myobject);
      InitializeStates();
   }

   protected override void OnUpdate()
   {
      //base.Update();
      if (Input.GetKeyDown(KeyCode.H))
      {
         TransitionToState(EEmotionState.Happy);
      }
      if (Input.GetKeyDown(KeyCode.S))
      {
         TransitionToState(EEmotionState.Sad);
      }
      if (Input.GetKeyDown(KeyCode.N))
      {
         TransitionToState(EEmotionState.Neutral);
      }
   }
   
   private void InitializeStates()
   {
      //Add states to inherited StateMachine "States" dictionary and Set Initial State
      States.Add(EEmotionState.Happy, new HappyState(_context,EEmotionState.Happy));
      States.Add(EEmotionState.Neutral, new NeutralState(_context,EEmotionState.Neutral));
      States.Add(EEmotionState.Sad, new SadState(_context,EEmotionState.Sad));
      CurrentState = States[EEmotionState.Neutral];
   }
}
