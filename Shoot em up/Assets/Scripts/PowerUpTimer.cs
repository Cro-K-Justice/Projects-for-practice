using UnityEngine;

public class PowerUpTimer 
{
    private float timer;
    private int multiplier;
    private EPowerUpType effectType;
    public bool needsRemoval;

    public PowerUpTimer(float time, int _multiplier, EPowerUpType _effectType)
    {
        timer = time;
        multiplier = _multiplier;
        effectType = _effectType;
    }
    public void UpdateTimer(PowerUpEffect powerUpManager)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            powerUpManager.DeactivateEffectType(effectType, multiplier);
            needsRemoval = true;
        }
    }
}
