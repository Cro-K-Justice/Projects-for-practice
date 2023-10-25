using UnityEngine;

public class Enemy : Character, IEnemy
{
    #region Test region
    public float GetDistanceToPlayerInfo()
    {
        return distanceToPlayer;
    }
    #endregion
    [SerializeField]
    private int coinDropValue = 1;
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private float distanceToPlayer = 1;
    private Transform player;

    private void Awake()
    {
        gameObject.tag = "Enemy";
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (shooting.CanShoot()) shooting.Shoot(realDamage);
    }
    private void FixedUpdate() 
    {
        if(player!=null)
        FollowPlayer();     
    }
    public void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > distanceToPlayer + realSpeed * Time.fixedDeltaTime) 
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, realSpeed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
            transform.LookAt(player);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnDestroy() 
    {
        if (!gameObject.scene.isLoaded) return;
        GameObject coinInstance = Instantiate(coinPrefab, transform.position, transform.rotation);
        Coin coin = coinInstance.GetComponent<Coin>();
        coinDropValue *= sumCoinMultiplier;
        coin.SetCoinValue(coinDropValue);
    }
}
