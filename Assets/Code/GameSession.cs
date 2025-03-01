using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance { get; private set; }

    [Header("Player Stats")]
    public int health;
    public int gem;

    [Header("UI References")]
    public TextMeshProUGUI txtGem;
    public Slider healthSlider;

    private AttributesManager currentPlayer; // Lưu Player hiện tại

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Liên tục cập nhật thanh máu theo GameSession
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }
    }

    public void SetCurrentPlayer(AttributesManager player)
    {
        if (player == null) return;

        currentPlayer = player;

        // Cập nhật máu của nhân vật theo GameSession
        if (health > 0)
        {
            currentPlayer.health = health;
        }
        else
        {
            health = currentPlayer.health;
        }

        // Đặt maxValue cố định là 100
        healthSlider.maxValue = 100;
        healthSlider.value = health;
    }


    public void UpdateHealth(int newHealth)
    {
        health = newHealth;

        if (currentPlayer != null)
        {
            currentPlayer.health = health;
        }
    }

    public void MaxHealth(int maxHealth)
    {
        healthSlider.maxValue = 100; // Giữ cố định maxValue là 100
    }


    public void IncreaseHealth(int value)
    {
        health += value;
        health = Mathf.Min(health, (int)healthSlider.maxValue);

        if (currentPlayer != null)
        {
            currentPlayer.health = health;
        }
    }

    public void UpdateGem(int amount)
    {
        gem += amount;
        txtGem.text = "Gem: " + gem;
    }
}
