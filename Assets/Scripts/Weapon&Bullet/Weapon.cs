using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public PlayerStats stats;
    public bool isPlayerWeapon = false;

    [SerializeField] private float damage;

    protected bool isShooting = false;

    public float Damage { get => damage; set => damage = value; }

    public abstract void StartShot();
    public abstract void StopShot();
}
