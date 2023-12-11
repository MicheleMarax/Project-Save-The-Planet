using UnityEngine;

public class HelpShip : MonoBehaviour
{
    public PlayerStats stats;

    public LayerMask enemiesLayer;

    private float startOffset = 1f;
    private Weapon weapon;

    [SerializeField] float rotatingSpeed;

    public Weapon Weapon { get => weapon; private set => weapon = value; }

    void Start()
    {
        transform.position = new Vector2(0, startOffset);
        weapon = GetComponent<Weapon>();
        weapon.isPlayerWeapon = false;
    }

    
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, rotatingSpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 20, enemiesLayer);

        if (hit == true && hit.collider.tag == "Enemy")
        {
            weapon.StartShot();
        }
        else
        {
            weapon.StopShot();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.up);
    }
}
