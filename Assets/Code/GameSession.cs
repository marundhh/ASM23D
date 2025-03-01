using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int health;
    public int gem;
    public TextMeshProUGUI txtGem;
    public Slider slider;

    private void Awake()
    {
        int numbersession = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numbersession > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
    public void MaxHealth(int health)
    {
        slider.maxValue = health;
    }
    public void UpdateHealth(int health)
    {
        this.health = health;
        slider.value = health;
    }
    public void UpdateGem(int x)
    {
        this.gem += x;
        txtGem.text = "Gem: " + this.gem;
    }
    public void IncreaseHealth(int value)
    {
        health += value;
        health = Mathf.Min(health, (int)slider.maxValue);
        slider.value = health;

        // Tìm nhân vật có AttributesManager
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            AttributesManager playerAttributes = player.GetComponent<AttributesManager>();
            if (playerAttributes != null)
            {
                playerAttributes.health = health; // Cập nhật máu của nhân vật
            }
        }
    }

}
