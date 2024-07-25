using UnityEngine;

public class EnemyProjectileAttacker : MonoBehaviour
{
    private const int PlayerLayer = 1 << 7;

    private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerLayer >> collision.gameObject.layer != 1 || _damage == 0)
            return;

        var playerHealth = collision.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage((int)_damage);
        Destroy(gameObject);
    }

    public void SetDamage(float damage) => _damage = damage;
}

