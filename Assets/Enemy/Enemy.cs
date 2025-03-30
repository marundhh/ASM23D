using UnityEngine;

public class Enemy : CreatureStats
{
    public override void TakeDamage(float damage)
    {
        float finalDamage = damage - currentArmor;
        finalDamage = Mathf.Max(finalDamage, 0);
        currentHealth -= finalDamage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
