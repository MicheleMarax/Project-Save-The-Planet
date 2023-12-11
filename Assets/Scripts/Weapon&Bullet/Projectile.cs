using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float time;

    float damage;
    float speed;

    public void Init(float damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
    }

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);

        Invoke(nameof(Destroy), time);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();

        if (hittable != null)
        {
            hittable.Hit(damage);
            Destroy();
        }
            
    }
}
