using System;
using UnityEngine;
using PolygonArsenal;

public class LaserState : State
{
    PolygonBeamStatic laser;
    float damageDelay;
    float damage;
    Transform point;
    LayerMask maskToCollide;

    float delayTmp;

    public LaserState(PolygonBeamStatic laser, float damageDelay, float damage, Transform point, LayerMask mask)
    {
        this.laser = laser ?? throw new ArgumentNullException(nameof(laser));
        this.damageDelay = damageDelay;
        this.damage = damage;
        delayTmp = 0;
        this.point = point;
        laser.gameObject.SetActive(false);
        maskToCollide = mask;
    }

    public override State CheckForNextState()
    {
        return this;
    }

    public override void StatePerform()
    {
        laser.gameObject.SetActive(true);

        if(delayTmp <= 0)
        {
            delayTmp = damageDelay;

            Vector2 dir = Vector2.zero - (Vector2)point.position;
            RaycastHit2D hit = Physics2D.Raycast(point.position, dir, 20, maskToCollide);

            if (!hit)
                return;
          
            IHittable hittable = hit.collider.GetComponent<IHittable>();

            if (hittable != null)
                hittable.Hit(damage);
        }

        delayTmp -= Time.deltaTime; 
    }
}
