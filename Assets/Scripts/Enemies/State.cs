using UnityEngine;

public abstract class State
{
    protected string stateName;
    protected State nextState;

    public string StateName { get => stateName;}

    public abstract void StatePerform();
    public abstract State CheckForNextState();

    protected void LookRotation(Transform transform)
    {
        Vector3 frontVector = -Vector3.up; // Set your front vector here

        Quaternion targetRotation = Quaternion.FromToRotation(frontVector, transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5f);
    }
}
