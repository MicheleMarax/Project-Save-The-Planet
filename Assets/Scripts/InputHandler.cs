using UnityEngine;

public class InputHandler : Singleton<InputHandler>
{
    [SerializeField] private Camera mainCamera;
    private bool isTouching = false;

    public Camera MainCamera { get => mainCamera;}
    public bool IsTouching { get => isTouching;}

    public delegate void PointerDown();
    public event PointerDown OnPointerDown;

    public delegate void PointerStay();
    public event PointerStay OnPointerStay;

    public delegate void PointerUp();
    public event PointerUp OnPointerUp;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnPointerDown?.Invoke();
            isTouching = true;
        }

        if(Input.GetMouseButton(0))
        {
            OnPointerStay?.Invoke();
        }

        if(Input.GetMouseButtonUp(0))
        {
            OnPointerUp?.Invoke();
            isTouching = false;
        }
    }

    public Vector2 ScreenToWorld2D()
    {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(PointerLocationOnScreen());

        return new Vector2(worldPos.x, worldPos.y);
    }

    public Vector3 PointerLocationOnScreen()
    {
        return Input.mousePosition;
    }

    
}
