using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DamagePowerUp : PowerUpEffect, IPowerUpEffect
{
    private float startDamage;
    protected override void Start()
    {
        base.Start();
        startDamage = character.GetStartDamage();
    }
    public override void PowerUp(int multiplier, float duration, EPowerUpType effectType)
    {
        base.PowerUp(multiplier, duration, effectType);
        character.SetRealDamage(sumMultiplier * startDamage);

        if (character.TryGetComponent(out Player player))
        {
            player.SetDamagePowerStatus(effectType + " is activated with multiplier: x" + sumMultiplier);
        }
    }
    public override void DeactivateEffectType(EPowerUpType effectType, int _multiplier)
    {
        base.DeactivateEffectType(effectType, _multiplier);
        character.SetRealDamage(sumMultiplier * startDamage);

        if (character.TryGetComponent(out Player player))
        {
            if (activePowerUp.Count > 0)
            {
                player.SetDamagePowerStatus(effectType + " is activated with multiplier: x" + sumMultiplier);
            }
            else
            {
                player.SetDamagePowerStatus(" ");
            }
        }
        Debug.Log("the Damage power up has gone out");
    }
}
