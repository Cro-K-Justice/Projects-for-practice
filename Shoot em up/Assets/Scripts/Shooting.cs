using UnityEngine;

public class Shooting : MonoBehaviour
{
    #region Test region

    public float GetRealShootFrequency()
    {
        return realShootFrequency;
    }
    public float GetprojectileLifeSpanInfo()
    {
        return projectileLifeSpan;
    }
    #endregion
    [SerializeField]
    private Projectile projectile;
    private float projectileSpeed = 10f;
    [SerializeField]
    private float projectileLifeSpan = 10f;
    [SerializeField]
    private Transform projectilePos;
    [SerializeField]
    private float realShootFrequency;
    [SerializeField]
    private float startShootFrequency;

    private float damage;

    private void Awake()
    {
        realShootFrequency = startShootFrequency;
    }
    private void Update()
    {
        if (CanShoot() == false)
        {
            realShootFrequency -= Time.deltaTime;
        }
    }
    public bool CanShoot()
    {
        return realShootFrequency  <= 0;
    }
    private void ProjectileInstantiate()
    {
        GameObject instProjectile = Instantiate(projectile.gameObject, projectilePos.position, Quaternion.identity);
        Projectile _projectile = instProjectile.GetComponent<Projectile>();
        _projectile.SetDamage(damage);
        Vector3 shootDirection = transform.forward.normalized;
        instProjectile.GetComponent<Rigidbody>().velocity = shootDirection * projectileSpeed;
        Destroy(instProjectile, projectileLifeSpan);
    }
    public void Shoot(float _damage)
    {
        damage = _damage;
        ProjectileInstantiate();
        realShootFrequency = startShootFrequency;
    }
    public void SetRealShootFrequency(float _realShootFrequency)
    {
        realShootFrequency = _realShootFrequency;
    }
}
