using UnityEngine;
using UnityEngine.TextCore.Text;

public enum EPowerUpType { SpeedMultiplier, CoinMultiplier, DamageMultiplier }

public class PowerUp : Collectible
{
    #region Test region
    public float GetDurationInfo()
    {
        return duration;
    }
    public int GetMultiplierInfo()
    {
        return multiplier;
    }
    #endregion
        
    [SerializeField]
    private float duration;
    [SerializeField]
    private int multiplier = 1;
    public EPowerUpType effectType;
    public override void Collect(GameObject collector)
    {
        base.Collect(collector);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            if (effectType == EPowerUpType.SpeedMultiplier)
            {
                SpeedPowerUp speedPowerUp = collision.gameObject.GetComponent<SpeedPowerUp>();
                speedPowerUp.PowerUp(multiplier, duration, effectType);
            }
            else if (effectType == EPowerUpType.DamageMultiplier)
            {
                DamagePowerUp damagePowerUp = collision.gameObject.GetComponent<DamagePowerUp>();
                damagePowerUp.PowerUp(multiplier, duration, effectType);
            }
            else if (effectType == EPowerUpType.CoinMultiplier)
            {
                CoinPowerUp coinPowerUp = collision.gameObject.GetComponent<CoinPowerUp>();
                coinPowerUp.PowerUp(multiplier, duration, effectType);
            }
            Debug.Log("Upaljen je: " + effectType);
            Collect(collision.gameObject);
        }
    }
}
