using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] CameraController cameraController;
    [SerializeField] PlayerController playerRotation;
    [SerializeField] SpawnManager spawnManager;

    public CameraController CameraController { get => cameraController; private set => cameraController = value; }
    public PlayerController PlayerRotation { get => playerRotation; private set => playerRotation = value; }
    public SpawnManager SpawnManager { get => spawnManager; private set => spawnManager = value; }

    public delegate void GameOverEvent();
    public event GameOverEvent OnGameOver;

    public delegate void GameStartEvent();
    public event GameStartEvent OnGameStart;

    private void Start()
    {
        StopGame();
    }

    public void GameOver()
    {
        StopGame();
        SpawnManager.DestroyAll();
        OnGameOver?.Invoke();
    }

    public void StopGame()
    {
        cameraController.SetMenuCamera();
        cameraController.StopMovement();
        spawnManager.StopSpawning();
    }

    public void StartGame()
    {
        cameraController.StartMovement();
        cameraController.SetPlayCamera();
        spawnManager.StartSpawning();
        OnGameStart?.Invoke();
    }


}

