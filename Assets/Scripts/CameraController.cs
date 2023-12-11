using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public PlayerStats stats;
    public float camSpeed = 100;

    [SerializeField] private Transform shipRotator;
    [SerializeField] private float gameCamSize = 5;

    private InputHandler inputHandler;
    private Camera cam;
    private int uniqueID;
    private bool canMove = false;
    
    public Camera Cam { get => cam;}

    private void Awake()
    {      
        cam = GetComponent<Camera>();
    }

    void Start()
    {
        inputHandler = InputHandler.instance;
        cam.orthographic = true;

        inputHandler.OnPointerStay += SetPointerDestination;
    }

    public void StopMovement()
    {
        ResetDestination();
        canMove = false;
    }
     
    public void StartMovement()
    {
        canMove = true;
    }

    public void SetPlayCamera()
    {
        LeanTween.value(gameObject, SetCameraSize, cam.orthographicSize, gameCamSize + (gameCamSize * stats.CamSizeMultiplier)/100, 1.5f).setEaseLinear(); 
    }

    public void SetMenuCamera()
    {
        LeanTween.value(gameObject, SetCameraSize, cam.orthographicSize, 3, 1.5f).setEaseLinear();
    }

    private void SetCameraSize(float val)
    {
        cam.orthographicSize = val;
    }

    private void SetPointerDestination()
    {
        if (!canMove)
            return;

        LeanTween.cancel(uniqueID);

        //Vector2 screenPos = inputHandler.ScreenToWorld2D();
        //screenPos = Vector2.ClampMagnitude(screenPos, maxDistance);

        uniqueID = transform.LeanMove(new Vector3(shipRotator.position.x, shipRotator.position.y, -10), camSpeed * Time.deltaTime).uniqueId;
    }

    private void ResetDestination()
    {
        LeanTween.cancel(uniqueID);
        uniqueID = gameObject.LeanMove(Vector2.zero, camSpeed * Time.deltaTime).uniqueId;
    }
}
