using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState; // Reference to the current state.

    void Update()
    {
        RunStateMachine(); // Calls the state machine at every frame.
    }
    
    private void RunStateMachine() // Its responsible for executing the current state and handling any state transitions.
    {
        // Call the RunCurrentState() method on the current state.
        // And store the returned next state in a local variable.
        State nextState = currentState?.RunCurrentState();

        // If the next state is not null, switch to the new state.
        if (nextState != null)
        {
            SwitchToNextState(nextState); 
        }
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState; // Update the current state to the new state.
    }
}
