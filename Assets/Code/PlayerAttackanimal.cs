using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 50; // Sát thương mỗi đòn chém

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            AnimalHealth animal = other.GetComponent<AnimalHealth>();
            if (animal != null)
            {
                animal.TakeDamage(damage);
            }
        }
    }
}
