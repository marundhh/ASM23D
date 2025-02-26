using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;        // Thời gian sống của đạn
    public int damage = 10;        // Sát thương của đạn

    void Awake()
    {
        Destroy(gameObject, life); // Tự huỷ sau life giây
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Lấy AttributesManager từ enemy
            AttributesManager enemyAttributes = collision.gameObject.GetComponent<AttributesManager>();
            if (enemyAttributes != null)
            {
                enemyAttributes.TackeDamage(damage); // Gây sát thương
            }
        }

        Destroy(gameObject); // Huỷ đạn sau va chạm
    }
}
