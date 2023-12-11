using System;
using UnityEngine;

public class MoveState : State
{
    private float moveSpeed;
    private Vector2 moveDestination;
    private float stopDistance;
    private Transform transform;

    public MoveState(float moveSpeed, Vector2 moveDestination, float stopDistance, Transform transform, State nextState)
    {
        stateName = "Move state";
        this.nextState = nextState;
        this.moveSpeed = moveSpeed;
        this.moveDestination = moveDestination;
        this.stopDistance = stopDistance;
        this.transform = transform ?? throw new ArgumentNullException(nameof(transform));
    }

    public override State CheckForNextState()
    {
        if (nextState == null)
            return this;

        //Debug.Log(Vector2.Distance(transform.position, moveDestination) + "    " + nextState.StateName);
        if (Vector2.Distance(transform.position, moveDestination) <= stopDistance)
            return nextState;

        return this;
    }

    public override void StatePerform()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveDestination, moveSpeed * Time.deltaTime);

        LookRotation(transform);
    }
}

