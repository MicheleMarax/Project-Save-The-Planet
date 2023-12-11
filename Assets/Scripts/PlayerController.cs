using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputHandler inputHandler;
    private float zAngle;
    private Weapon weapon;

    [SerializeField] float movSpeed;

    public PlayerStats stats;
    public LayerMask enemyMask;

    void Start()
    {
        inputHandler = InputHandler.instance;
        weapon = GetComponentInChildren<Weapon>();
    }

    
    void Update()
    {
        FacePointer();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 20, enemyMask);

        //Debug.Log(hit.collider);

        if(hit == true && hit.collider.tag == "Enemy")
        {
            weapon.StartShot();
        }
        else
        {
            weapon.StopShot();
        }
    }

    private void FacePointer()
    {
        Vector3 pointerPosition = inputHandler.PointerLocationOnScreen();

        if(inputHandler.IsTouching)
        {
            zAngle = (movSpeed + (movSpeed * stats.PlayerSpeedMultiplier)/100) * Time.deltaTime;
        }
        else
        {
            zAngle = 0;
        }

        if(ScreenHelper.IsPointingRightScreen(pointerPosition, 50f)) //Giro in senso orario
        {
            transform.Rotate(0, 0, -zAngle);
        }    
        else if (ScreenHelper.IsPointingLeftScreen(pointerPosition, 50f)) //Giro in senso antiorario
        {
            transform.Rotate(0, 0, zAngle);
        }
        else
        {
            zAngle = 0;
        }

        //Vector2 dir = new Vector2(
        //    pointerPosition.x - transform.position.x,
        //    pointerPosition.y - transform.position.y);

        //if(dir != Vector2.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, stats.playerSpeed * Time.deltaTime);
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.up * 20);
    }

}
