using UnityEngine;

[System.Serializable]
public class SpawnableItem
{
    [SerializeField] EnemyBase enemyObject;
    [SerializeField] int costToSpawn;

    public EnemyBase EnemyObject { get => enemyObject;}
    public int CostToSpawn { get => costToSpawn;}
}
