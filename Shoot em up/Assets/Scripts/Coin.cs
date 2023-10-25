using UnityEngine;

public class Coin : Collectible
{
    #region Test region
    public int GetCoinValueInfo()
    {
        return value;
    }
    #endregion
    [SerializeField]
    private int value;
    public void SetCoinValue(int _value)
    {
        value = _value;
    }
    public override void Collect(GameObject collector)
    {
        if (collector.tag == "Player")
        {
            Player player = collector.GetComponent<Player>();
            player.AddScore(value);
        }
        base.Collect(collector);
    }
    private void OnCollisionEnter(Collision collision)
    {       
        Collect(collision.gameObject);
    }
}
