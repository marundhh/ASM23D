using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{
    public GameObject[] images; // Mảng chứa tất cả Image

    void Start()
    {
        ShowOnlyImage(0); // Hiện Image đầu tiên khi bắt đầu
    }

    void Update()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ShowOnlyImage(i); // Hiển thị Image tương ứng
            }
        }
    }

    void ShowOnlyImage(int index)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(i == index); // Chỉ bật Image được chọn
        }
    }
}
