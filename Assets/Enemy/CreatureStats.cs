using UnityEngine;

public abstract class CreatureStats : MonoBehaviour
{
    [Header("MAX STATS")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float maxArmor;
    [SerializeField] protected float maxMana;
    [SerializeField] protected float maxPhysicalDamage;
    [SerializeField] protected float maxMagicDamage;
    [SerializeField] protected float maxCooldownReduction;
    [SerializeField] protected float maxMoveSpeed;
    [SerializeField] protected float maxAttackSpeed;

    [Header("---------------------------")]

    [Header("CURRENT STATS")]
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float currentArmor;
    [SerializeField] protected float currentMana;
    [SerializeField] protected float currentPhysicalDamage;
    [SerializeField] protected float currentMagicDamage;
    [SerializeField] protected float currentCooldownReduction;
    [SerializeField] protected float currentMoveSpeed;
    [SerializeField] protected float currentAttackSpeed;

    protected void Start()
    {
        Debug.Log("Start Creature");
        currentHealth = maxHealth;
        currentArmor = maxArmor;
        currentMana = maxMana;
        currentPhysicalDamage = maxPhysicalDamage;
        currentMagicDamage = maxMagicDamage;
        currentCooldownReduction = maxCooldownReduction;
        currentMoveSpeed = maxMoveSpeed;
        currentAttackSpeed = maxAttackSpeed;
    }

    public abstract void TakeDamage(float damage);

    public abstract void Die();
}