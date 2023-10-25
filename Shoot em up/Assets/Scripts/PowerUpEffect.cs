using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpEffect : MonoBehaviour
{
    protected int sumMultiplier;

    protected List<PowerUpTimer> powerUpTimer = new List<PowerUpTimer>();

    protected List<int> activePowerUp = new List<int>();

    protected Character character;

    protected virtual void Start()
    {
        character = GetComponent<Character>();
    }
    private void Update()
    {
        for (int i = powerUpTimer.Count - 1; i >= 0; i--)
        {
            var timer = powerUpTimer[i];
            timer.UpdateTimer(this);

            if (timer.needsRemoval)
            {
                powerUpTimer.RemoveAt(i);
            }
        }
    }
    protected void AddPowerUpTimer(int multiplier, float duration, EPowerUpType effectType)
    {
        PowerUpTimer powerUpTimers = new PowerUpTimer(duration, multiplier, effectType);
        powerUpTimer.Add(powerUpTimers);
    }
    protected virtual void SumMultiplier()
    {
        sumMultiplier = activePowerUp.Count == 0 ? 1 : 0;
        foreach (int number in activePowerUp)
        {
            sumMultiplier += number;
        }

    }
    public virtual void PowerUp(int multiplier, float duration, EPowerUpType effectType)
    {   
        activePowerUp.Add(multiplier);
        AddPowerUpTimer(multiplier, duration, effectType);
        SumMultiplier();
    }
    private void Reduce(int _multiplier)
    {
        activePowerUp.Remove(_multiplier);
        SumMultiplier();      
    }
    public virtual void DeactivateEffectType(EPowerUpType ePowerUp, int _multiplier)
    {
        Reduce(_multiplier);
    }
}
