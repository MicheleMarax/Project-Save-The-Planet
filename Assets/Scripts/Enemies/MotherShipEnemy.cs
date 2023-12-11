using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipEnemy : EnemyBase
{
    [SerializeField] float orbitSpeed;
    [SerializeField] bool clockwise;
    [SerializeField] float orbitingTime;
    [SerializeField] float stopDistance;
    [SerializeField] GameObject[] enemies;

    private MoveState moveState;
    private OrbitingState orbitingState;
    private SpawnerState spawnerState;

    protected override void Start()
    {
        base.Start();

        spawnerState = new SpawnerState(enemies, transform);
        orbitingState = new OrbitingState(orbitSpeed, clockwise, orbitingTime, transform, spawnerState);
        spawnerState.SetNextState(orbitingState);
        moveState = new MoveState(moveSpeed, Vector2.zero, stopDistance, transform, orbitingState);

        currentState = moveState;
    }
}
