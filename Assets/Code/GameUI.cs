using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public class GameHUD
    {
        public bool IsVisible { get; private set; } = true;

        public void ToggleHUD()
        {
            IsVisible = !IsVisible;
        }
    }

    public class InventoryUI
    {
        public bool IsOpen { get; private set; } = false;

        public void OpenInventory()
        {
            IsOpen = true;
        }

        public void CloseInventory()
        {
            IsOpen = false;
        }
    }

    public class GameSettings
    {
        public int Volume { get; private set; } = 50;

        public void SetVolume(int value)
        {
            if (value >= 0 && value <= 100)
            {
                Volume = value;
            }
        }
    }
}
