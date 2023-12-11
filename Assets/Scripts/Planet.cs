using UnityEngine;

[RequireComponent(typeof(Health))]
public class Planet : MonoBehaviour, IHittable
{
    Health health;
    Collider2D col;

    private void Start()
    {
        TryGetComponent<Health>(out health);
        TryGetComponent<Collider2D>(out col);

        GameManager.instance.OnGameStart += EnablePlanetHit;
        GameManager.instance.OnGameOver += DisablePlanetHit;
    }

    public void Hit(float damage)
    {
        if(health.Damage(damage))
        {
            //GameManager.instance.Exit();          
            GameManager.instance.StopGame();
            FindObjectOfType<GameUI>().OpenGameOverPage();
        }
    }

    private void DisablePlanetHit()
    {
        col.enabled = false;
    }

    private void EnablePlanetHit()
    {
        health.ResetHealth();
        col.enabled = true;
    }
}
