using UnityEngine;
using System;
using UnityEditor.Timeline;

public abstract class EmotionState : BaseState<EmotionStateMachine.EEmotionState> 
{
    protected EmotionContext Context;

    public EmotionState(EmotionContext context,EmotionStateMachine.EEmotionState stateID) : base(stateID)
    {
        Context = context;
    }

    public void ChangeMaterial(GameObject obj, int index, ChangeMaterial materials)
    {
        obj.GetComponent<MeshRenderer>().material = materials._materials[index];
    }
    
}
