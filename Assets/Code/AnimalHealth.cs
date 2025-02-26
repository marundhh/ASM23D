using UnityEngine;

public class AnimalHealth : MonoBehaviour
{
    [Header("Animal Settings")]
    public string animalName = "Animal";   // Tên riêng của Animal
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Meat Settings")]
    public GameObject meatPrefab;          // Prefab thịt
    public Transform meatSpawnPoint;       // Vị trí xuất hiện thịt

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log($"{animalName} bị tấn công! Máu còn lại: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log($"{animalName} đã chết!");

        if (meatPrefab != null)
        {
            Vector3 spawnPosition = meatSpawnPoint != null ? meatSpawnPoint.position : transform.position;
            GameObject meat = Instantiate(meatPrefab, spawnPosition, Quaternion.identity);

            // Gắn tên Animal lên thịt (nếu prefab có Meat script)
            Meat meatScript = meat.GetComponent<Meat>();
            if (meatScript != null)
            {
                meatScript.SetMeatName($"{animalName} Meat");
            }
        }

        Destroy(gameObject); // Xóa Animal sau khi chết
    }
}
