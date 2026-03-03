using UnityEngine;

public abstract class NeedState : BaseState<NeedsStatemachine.ENeedState>
{
   protected NeedContext Context;
   
   public NeedState(NeedContext context,NeedsStatemachine.ENeedState stateID) : base(stateID)
   {
      Context = context;
   }
}
