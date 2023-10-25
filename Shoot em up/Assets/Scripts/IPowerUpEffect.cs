
public interface IPowerUpEffect 
{
    void PowerUp(int multiplier, float duration, EPowerUpType effectType);
    void DeactivateEffectType(EPowerUpType ePowerUp, int _multiplier);
}
