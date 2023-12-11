using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<SpawnableItem> spawnableItems;
    [SerializeField] AnimationCurve wavesCurrency;
    [SerializeField] float spawnDelay;
    [SerializeField] float waveDelay;
    [SerializeField] float distanceToSpawn;

    private int currentWave;
    private List<EnemyBase> enemiesToGenerate;
    private Camera cam;
    private bool isGenerating = false;

    public bool IsGenerating { get => isGenerating;}

    public delegate void DestroyAllEnemies();
    public event DestroyAllEnemies OnDestroyAll;

    void Start()
    {
        currentWave = 0;
        enemiesToGenerate = new List<EnemyBase>();
        cam = GameManager.instance.CameraController.Cam;
    }

    public void StartSpawning()
    {
        if (!IsGenerating)
        {
            isGenerating = true;
            StartCoroutine(nameof(SpawnWaves));
        }
           
    }

    public void DestroyAll()
    {
        OnDestroyAll?.Invoke();
    }

    public void StopSpawning()
    {
        if(IsGenerating)
        {
            StopCoroutine(nameof(SpawnWaves));
            isGenerating = false;
        }
           
    }

    private void GenerateEnemies()
    {
        enemiesToGenerate.Clear();

        int currency = (int)wavesCurrency.Evaluate(currentWave);

        int cycleRepeat = 0;
        while(currency > 0)
        {
            int itemId = Random.Range(0, spawnableItems.Count);
            int itemCost = spawnableItems[itemId].CostToSpawn;

            if(currency - itemCost >= 0)
            {
                enemiesToGenerate.Add(spawnableItems[itemId].EnemyObject);
                currency -= itemCost;
            }
            else if(currency <= 0 || cycleRepeat >= spawnableItems.Count)
            {
                break;
            }
            else
            {
                cycleRepeat++;
            }
        }
    }

    private IEnumerator SpawnWaves()
    {
        while(true)
        {
            GenerateEnemies();

            for (int i = 0; i < enemiesToGenerate.Count; i++)
            {
                EnemyBase tmp = Instantiate(enemiesToGenerate[i], GetSpawnLocation(), Quaternion.identity);

                yield return new WaitForSeconds(spawnDelay);
            }

            yield return new WaitForSeconds(waveDelay);
            currentWave++;
        }
    }

    private Vector3 GetSpawnLocation()
    {
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        dir *= distanceToSpawn;

        if (!ScreenHelper.IsInsideBounds(dir, cam))
            return new Vector3(dir.x, dir.y, 0);

        return Vector3.zero;
    }
}
