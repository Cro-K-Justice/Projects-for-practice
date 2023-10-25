using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooting))]
[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    #region Test region
    public float GetRealDamage()
    {
        return realDamage;
    }
    public float GetHealth()
    {
        return health;
    }
    public float GetRealSpeed()
    {
        return realSpeed;
    }
    #endregion

    [SerializeField]
    protected float startSpeed = 3f;
    [SerializeField]
    protected float startDamage = 1f;
    [SerializeField]
    protected float realSpeed;
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float realDamage;

    protected int sumCoinMultiplier = 1;

    protected Rigidbody rb;

    protected Shooting shooting;

    protected virtual void Start()
    {
        shooting = GetComponent<Shooting>();
        rb = GetComponent<Rigidbody>();
        realSpeed = startSpeed;
        realDamage = startDamage;       
    }
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
    }
    public float GetStartSpeed()
    {
        return startSpeed;
    }
    public void SetRealSpeed(float setRealSpeed)
    {
        realSpeed = setRealSpeed;
    }
    public float GetStartDamage()
    {
        return startDamage;
    }
    public void SetRealDamage(float setRealDamage)
    {
        realDamage = setRealDamage;
    }
    public void SetCoinSum(int coinSum)
    {
        sumCoinMultiplier = coinSum;
    }
    public bool TryGetPowerUp(EPowerUpType powerUpType, out PowerUpEffect powerUp)
    {
        bool bSuccess = false;
        switch (powerUpType)
        {
            case EPowerUpType.SpeedMultiplier:
                bSuccess = gameObject.TryGetComponent(out SpeedPowerUp speedPowerUp);
                powerUp = bSuccess ? (PowerUpEffect)speedPowerUp : null;
                break;
            case EPowerUpType.CoinMultiplier:
                bSuccess = gameObject.TryGetComponent(out CoinPowerUp coinPowerUp);
                powerUp = bSuccess ? (PowerUpEffect)coinPowerUp : null;
                break;
            case EPowerUpType.DamageMultiplier:
                bSuccess = gameObject.TryGetComponent(out DamagePowerUp damagePowerUp);
                powerUp = bSuccess ? (PowerUpEffect)damagePowerUp : null;
                break;
            default:
                powerUp = null;
                break;
        }
        return bSuccess;
    }
}
