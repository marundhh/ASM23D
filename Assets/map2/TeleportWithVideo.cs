using UnityEngine;

public class TeleportWithEffectAndImage : MonoBehaviour
{
    public Transform teleportDestination; // Điểm đến sau khi hiển thị hình ảnh
    public GameObject teleportEffect; // Hiệu ứng trước khi hiện hình ảnh
    public GameObject teleportImage; // Hình ảnh hiển thị trước khi teleport
    public float effectDuration = 0.5f; // Thời gian hiển thị hiệu ứng
    public float imageDuration = 0.5f; // Thời gian hiển thị hình ảnh
    private GameObject player;

    private void Start()
    {
        teleportEffect.SetActive(false); // Ẩn hiệu ứng lúc đầu
        teleportImage.SetActive(false); // Ẩn hình ảnh lúc đầu
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nếu là người chơi
        {
            player = other.gameObject;
           
            teleportEffect.SetActive(true); // Hiển thị hiệu ứng
            Invoke("ShowTeleportImage", effectDuration);
        }
    }

    private void ShowTeleportImage()
    {
        teleportEffect.SetActive(false); // Ẩn hiệu ứng
        teleportImage.SetActive(true); // Hiển thị hình ảnh
        Invoke("TeleportPlayer", imageDuration);
    }

    private void TeleportPlayer()
    {
        teleportImage.SetActive(false); // Ẩn hình ảnh
        player.transform.position = teleportDestination.position; // Dịch chuyển nhân vật
        
    }
}