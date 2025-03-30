using Fusion;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    [Networked] private Color PlayerColor { get; set; }

    public void SetColor(Color color)
    {
        PlayerColor = color;
        ApplyColor();
    }

    public override void Spawned()
    {
        ApplyColor(); // Khi nhân vật xuất hiện, cập nhật màu ngay
    }

    private void ApplyColor()
    {
        Renderer renderer = GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = PlayerColor;
        }
    }
    

}
