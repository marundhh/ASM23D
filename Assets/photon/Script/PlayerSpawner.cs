using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject[] PlayerPrefabs; // Mảng chứa nhiều loại Player

    public void PlayerJoined(PlayerRef player)
    {
        if (PlayerPrefabs == null || PlayerPrefabs.Length == 0)
        {
            Debug.LogError("Chưa gán PlayerPrefabs! Kiểm tra lại trong Inspector.");
            return;
        }

        if (player == Runner.LocalPlayer)
        {
            // Chọn ngẫu nhiên một loại Player từ mảng
            int randomIndex = Random.Range(0, PlayerPrefabs.Length);
            GameObject chosenPrefab = PlayerPrefabs[randomIndex];

            // Spawn player
            Runner.Spawn(chosenPrefab, new Vector3(0, 0, 0), Quaternion.identity,
                player, (runner, obj) =>
                {
                    var _player = obj.GetComponent<PlayerSetup>();
                   
                }
            );
        }
    }
}
