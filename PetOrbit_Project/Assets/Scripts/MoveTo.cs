// MoveTo.cs

using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

    private NavMeshAgent agent;
    public Transform goal;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = goal.position;
    }
}