using UnityEngine;
using MoreMountains.Feedbacks;

[RequireComponent(typeof(Collider2D))]
public abstract class EnemyBase : MonoBehaviour, IHittable 
{
    [SerializeField] private string currentStateName;
    protected State currentState;

    [SerializeField] protected MMF_Player feedback;

    [Header("Enemy stats")]
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Health health;
    [SerializeField] protected int xp;

    protected virtual void Start()
    {
        GameManager.instance.SpawnManager.OnDestroyAll += DestroyNoEffect;
    }

    private void OnDestroy()
    {
        GameManager.instance.SpawnManager.OnDestroyAll -= DestroyNoEffect;
    }

    void Update()
    {
        if (currentState == null)
            return;

        currentState.StatePerform();
        currentState = currentState.CheckForNextState();
        currentStateName = currentState.StateName;
    }

    public void Hit(float damage)
    {
        if(health == null)
        {
            throw new System.Exception("No Health here: " + name);
        }

        if (health.Damage(damage))
            Destroy();
    }

    private void Destroy()
    {
        feedback.PlayFeedbacks();
        Destroy(gameObject);
        UpgradeHandler.instance.AddXp(xp);
    }

    private void DestroyNoEffect()
    {
        feedback.RemoveFeedback(0);
        feedback.PlayFeedbacks();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();

        if(hittable != null)
        {
            hittable.Hit(10);
            Destroy(gameObject);
        }
    }
}
