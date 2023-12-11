using UnityEngine;

public class Health : MonoBehaviour
{
    public PlayerStats stats;
    float maxHealth;
    [SerializeField] float startMaxHealth;
    float currentHealth;

    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; private set => currentHealth = Mathf.Clamp(value, 0, maxHealth); }

    public delegate void DamageTaken();
    public event DamageTaken OnHealthChanges;

    private void Start()
    {
        UpdateMaxHealth();
        CurrentHealth = maxHealth;
    }

    private void SetMaxHealth(float newMaxHealth)
    {
        float oldMax = maxHealth;
        maxHealth = newMaxHealth;

        currentHealth = (currentHealth * maxHealth) / oldMax;

        OnHealthChanges?.Invoke();
    }

    public void UpdateMaxHealth()
    {
        if (stats != null)
            SetMaxHealth(startMaxHealth + ((startMaxHealth * stats.HealthMultiplier) / 100));
        else
            maxHealth = startMaxHealth;
    }

    public void ResetHealth()
    {
        currentHealth = startMaxHealth;
        maxHealth = startMaxHealth;
        OnHealthChanges?.Invoke();
    }

    public bool Damage(float damage)
    {
        CurrentHealth -= damage;
        
        OnHealthChanges?.Invoke();

        if (CurrentHealth <= 0)
            return true;

        return false;
    }
}

