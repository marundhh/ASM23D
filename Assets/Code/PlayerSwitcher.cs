using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject[] players; // Các player trong game
    private int currentIndex = 0; // Player hiện tại

    void Start()
    {
        // Ẩn tất cả player và camera
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(i == 0); // Chỉ bật player đầu tiên
            TogglePlayerCamera(players[i], i == 0); // Bật camera cho player đầu
        }
    }

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchPlayer(i); // Chuyển player
            }
        }
    }

    void SwitchPlayer(int newIndex)
    {
        if (newIndex == currentIndex) return; // Không làm gì nếu chọn player hiện tại

        GameObject currentPlayer = players[currentIndex];
        GameObject newPlayer = players[newIndex];

        // Chuyển vị trí player mới sang chỗ player cũ
        newPlayer.transform.SetPositionAndRotation(currentPlayer.transform.position, currentPlayer.transform.rotation);

        // Tắt player cũ và camera
        currentPlayer.SetActive(false);
        TogglePlayerCamera(currentPlayer, false);

        // Bật player mới và camera
        newPlayer.SetActive(true);
        TogglePlayerCamera(newPlayer, true);

        currentIndex = newIndex; // Cập nhật player hiện tại
    }

    void TogglePlayerCamera(GameObject player, bool isActive)
    {
        Camera playerCamera = player.GetComponentInChildren<Camera>();
        if (playerCamera != null)
        {
            playerCamera.enabled = isActive; // Bật/tắt camera
        }
    }
}
