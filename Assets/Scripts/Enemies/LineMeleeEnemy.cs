using UnityEngine;

public class LineMeleeEnemy : EnemyBase
{
    private State moveState;

    protected override void Start()
    {
        base.Start();

        moveState = new MoveState(moveSpeed, Vector2.zero, 0f, transform, moveState);
        currentState = moveState;
    }
}
