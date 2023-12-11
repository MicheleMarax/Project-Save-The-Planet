using UnityEngine;

public class SpawnerState : State
{
    GameObject[] enemies;
    Transform transform;

    public SpawnerState(GameObject[] enemies, Transform transform)
    {
        this.enemies = enemies;
        this.transform = transform;
    }

    public override State CheckForNextState()
    {
        if (nextState != null)
            return nextState;
        else
            Debug.LogWarning("Here should be next state");

        return this;
    }

    public void SetNextState(State state)
    {
        nextState = state;
    }

    public override void StatePerform()
    {
        GameObject.Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
    }
}
