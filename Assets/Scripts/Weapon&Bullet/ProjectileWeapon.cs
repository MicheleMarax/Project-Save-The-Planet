using UnityEngine;
using MoreMountains.Feedbacks;

public class ProjectileWeapon : Weapon
{
    public Projectile projectile;
    public MMF_Player feedback;

    private float rateoTmp;
    protected float currentRateo;

    [SerializeField]protected float rateo;

    private void Start()
    {
        currentRateo = rateo;
    }

    public override void StartShot()
    {
        isShooting = true;     
    }

    public override void StopShot()
    {
        isShooting = false;
    }

    private void Update()
    {
        if(isPlayerWeapon)
            currentRateo = rateo - ((rateo * stats.RateoMultiplier) / 100);

        rateoTmp += Time.deltaTime;
        rateoTmp = Mathf.Clamp(rateoTmp, 0.1f, currentRateo);

        if (rateoTmp >= currentRateo && isShooting)
        {
            float currentDamage = Damage;

            if (isPlayerWeapon)
                currentDamage = Damage + (Damage * stats.DamageMultiplier) / 100;

            feedback.PlayFeedbacks();
            Instantiate(projectile, transform.position, transform.rotation).Init(currentDamage, 3f);
            rateoTmp = 0;
        }

    }
}

