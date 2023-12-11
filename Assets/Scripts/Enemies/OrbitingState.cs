using System;
using UnityEngine;

public class OrbitingState : State
{
    private float orbitingSpeed;
    private float orbitingRadius;
    private bool clockwise;
    private float orbitingTime;
    private Transform transform;

    private float tmp_orbitingTime;

    public OrbitingState(float orbitingSpeed, bool clockwise, float orbitingTime, Transform transform, State nextState)
    {
        this.orbitingSpeed = orbitingSpeed;
        this.clockwise = clockwise;
        this.orbitingTime = orbitingTime;
        this.transform = transform ?? throw new ArgumentNullException(nameof(transform));
        this.nextState = nextState;
    }

    public override State CheckForNextState()
    {
        if (nextState == null)
            return this;

        tmp_orbitingTime -= Time.deltaTime;

        if(tmp_orbitingTime <= 0)
        {
            tmp_orbitingTime = orbitingTime;
            return nextState;
        }
        else
        {
            return this;
        }
    }

    public override void StatePerform()
    {
        if(!clockwise)
            transform.RotateAround(Vector3.zero, Vector3.forward, orbitingSpeed * Time.deltaTime);
        else
            transform.RotateAround(Vector3.zero, Vector3.forward, -orbitingSpeed * Time.deltaTime);

    }
}
