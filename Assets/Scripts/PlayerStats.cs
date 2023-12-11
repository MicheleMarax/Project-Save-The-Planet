using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private float damagePercentage;
    [SerializeField] private float rateoPercentace;
    [SerializeField] private float playerSpeedPercentage;
    [SerializeField] private float camSizePercentage;
    [SerializeField] private float healthMultiplier;
    [SerializeField] private HelpShip ship;

    public float DamageMultiplier { get => damagePercentage; set => damagePercentage = value; }
    public float CamSizeMultiplier
    {
        get => camSizePercentage;
        set
        {
            camSizePercentage = value;
            GameManager.instance.CameraController.SetPlayCamera();
        }
    }
    public float PlayerSpeedMultiplier { get => playerSpeedPercentage; set => playerSpeedPercentage = value; }
    public float RateoMultiplier { get => rateoPercentace; set => rateoPercentace = value; }
    public float HealthMultiplier { get => healthMultiplier;
        set
        {
            healthMultiplier = value;
            GameObject.FindGameObjectWithTag("Planet").GetComponent<Health>().UpdateMaxHealth();
        }
    }
    public HelpShip Ship { get => ship; set => ship = value; }


    #region RESET
    private void OnDisable()
    {
        ResetStats();
    }

    public void ResetStats()
    {
        damagePercentage = 0;
        rateoPercentace = 0;
        playerSpeedPercentage = 0;
        camSizePercentage = 0;
        healthMultiplier = 0;

        if (ship != null)
            Destroy(ship.gameObject);
    } 
    #endregion
}
