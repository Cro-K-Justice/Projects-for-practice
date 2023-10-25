using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Character character = collision.gameObject.GetComponent<Character>();
            character.TakeDamage(damage);
            Destroy(gameObject);
        }      
    }
}
