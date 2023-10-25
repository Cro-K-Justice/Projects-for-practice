using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CoinPowerUp : PowerUpEffect, IPowerUpEffect
{
    public override void PowerUp(int multiplier, float duration, EPowerUpType effectType)
    {
        base.PowerUp(multiplier, duration, effectType);
        character.SetCoinSum(sumMultiplier);

        if (character.TryGetComponent(out Player player))
        {
            player.SetCoinPowerStatus(effectType + " is activated with multiplier: x" + sumMultiplier);
        }
    }
    public override void DeactivateEffectType(EPowerUpType effectType, int _multiplier)
    {
        base.DeactivateEffectType(effectType, _multiplier);
        character.SetCoinSum(sumMultiplier);

        if (character.TryGetComponent(out Player player))
        {
            if (activePowerUp.Count > 0)
            {
                player.SetCoinPowerStatus(effectType + " is activated with multiplier: x" + sumMultiplier);
            }
            else
            {
                player.SetCoinPowerStatus(" ");
            }
        }
        Debug.Log("the Coin power up has gone out");
    }
}
