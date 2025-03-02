using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveDataThread : MonoBehaviour
{
    public TMP_InputField inputField1; // Cột 1
    public TMP_InputField inputField2;
    public Button saveButton;      // Nút lưu
    private string path;

    private void Start()
    {
        path = Application.persistentDataPath + "/SaveData.txt";
        saveButton.onClick.AddListener(SaveData);
    }

    private void SaveData()
    {
        string data1 = inputField1.text;
        string data2 = inputField2.text;

        Thread thread = new Thread(() =>
        {
            string content = $"Tên đăng nhập: {data1}\nMật khẩu: {data2}\n";
            File.AppendAllText(path, content);
            Debug.Log($"Dữ liệu đã lưu vào: {path}");
        });

        thread.Start();
    }
}

