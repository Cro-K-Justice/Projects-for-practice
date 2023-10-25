using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUpEffect, IPowerUpEffect
{
    private float startSpeed;
    protected override void Start()
    {
        base.Start();
        startSpeed = character.GetStartSpeed();
    }
    protected override void SumMultiplier()
    {
        base.SumMultiplier();
        if (sumMultiplier > 10)
        {
            sumMultiplier = 10;
        }
    }
    public override void PowerUp(int multiplier, float duration, EPowerUpType effectType)
    {
        base.PowerUp(multiplier, duration, effectType);
        character.SetRealSpeed(sumMultiplier * startSpeed);

        if (character.TryGetComponent(out Player player))
        {
            if (sumMultiplier == 10)
            {
                player.SetSpeedPowerStatus(effectType + " is activated with MAX multiplier: x" + sumMultiplier);
            }
            else
            {
                player.SetSpeedPowerStatus(effectType + " is activated with multiplier: x" + sumMultiplier);
            }
        }
    }
    public override void DeactivateEffectType(EPowerUpType effectType, int _multiplier)
    {
        base.DeactivateEffectType(effectType, _multiplier);
        character.SetRealSpeed(sumMultiplier * startSpeed);

        if (character.TryGetComponent(out Player player))
        {
            if (activePowerUp.Count > 0)
            {
                player.SetSpeedPowerStatus(effectType + " is activated with multiplier: x" + sumMultiplier);
            }
            else
            {
                player.SetSpeedPowerStatus(" ");
            }
        }
        Debug.Log("the speed power up has gone out");
    }
}
