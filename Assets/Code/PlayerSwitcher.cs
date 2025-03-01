using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject[] players; // Danh sách Player
    private int currentIndex = 0; // Player hiện tại

    void Start()
    {
        // Ẩn tất cả player, chỉ bật player đầu tiên
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(i == 0);
            TogglePlayerCamera(players[i], i == 0);
        }

        // Cập nhật GameSession với Player đầu tiên
        GameSession.Instance.SetCurrentPlayer(players[0].GetComponent<AttributesManager>());
    }

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchPlayer(i); // Chuyển player khi nhấn phím số
            }
        }
    }

    void SwitchPlayer(int newIndex)
    {
        if (newIndex == currentIndex) return; // Không đổi nếu chọn lại chính mình

        GameObject currentPlayer = players[currentIndex];
        GameObject newPlayer = players[newIndex];

        // Lưu lại máu của Player cũ vào GameSession
        AttributesManager oldAttributes = currentPlayer.GetComponent<AttributesManager>();
        if (oldAttributes != null)
        {
            GameSession.Instance.UpdateHealth(oldAttributes.health);
        }

        // Chuyển vị trí player mới sang chỗ player cũ
        newPlayer.transform.SetPositionAndRotation(currentPlayer.transform.position, currentPlayer.transform.rotation);

        // Tắt player cũ và camera
        currentPlayer.SetActive(false);
        TogglePlayerCamera(currentPlayer, false);

        // Bật player mới và camera
        newPlayer.SetActive(true);
        TogglePlayerCamera(newPlayer, true);

        // Cập nhật Player mới vào GameSession
        GameSession.Instance.SetCurrentPlayer(newPlayer.GetComponent<AttributesManager>());

        currentIndex = newIndex; // Cập nhật player hiện tại
    }

    void TogglePlayerCamera(GameObject player, bool isActive)
    {
        Camera playerCamera = player.GetComponentInChildren<Camera>();
        if (playerCamera != null)
        {
            playerCamera.enabled = isActive;
        }
    }
}
