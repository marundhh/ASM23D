using UnityEngine;

public class Meat : MonoBehaviour
{
    private string meatName = "Meat";

    public void SetMeatName(string name)
    {
        meatName = name;
        Debug.Log($"Spawned: {meatName}");
    }

    // Có thể thêm logic khi Player nhặt thịt
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Player nhặt {meatName}");
            Destroy(gameObject); // Xóa thịt sau khi nhặt
        }
    }
}
