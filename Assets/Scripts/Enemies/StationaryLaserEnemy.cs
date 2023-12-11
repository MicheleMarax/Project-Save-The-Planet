using UnityEngine;
using PolygonArsenal;

public class StationaryLaserEnemy : EnemyBase
{
    public PolygonBeamStatic laser;
    public LayerMask mask;

    [SerializeField] float stopDistance;
    [SerializeField] float damage;
    [SerializeField] float damageDelay;

    private MoveState moveState;
    private LaserState laserState;

    protected override void Start()
    {
        base.Start();

        laserState = new LaserState(laser, damageDelay, damage, laser.transform, mask);
        moveState = new MoveState(moveSpeed, Vector2.zero, stopDistance, transform, laserState);
        currentState = moveState;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(laser.transform.position, laser.transform.up*20);
    }
}

