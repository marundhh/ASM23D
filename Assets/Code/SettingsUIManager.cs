using UnityEngine;

public class SettingsUIManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainButtons;

    private bool isSettingsOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isSettingsOpen)
        {
            OpenSettings();
        }
    }

    public void OpenSettings()
    {
        AudioManager.Instance.PlaySoundEffect("click");
        settingsPanel.SetActive(true);
        isSettingsOpen = true;
        //mainButtons.SetActive(false);
    }

    public void CloseSettings()
    {
        AudioManager.Instance.PlaySoundEffect("click");
        settingsPanel.SetActive(false);
        isSettingsOpen = false;
        //mainButtons.SetActive(true);
    }

    public void ToggleSettings()
    {
        if (settingsPanel != null)
        {
            bool isActive = settingsPanel.activeSelf;
            settingsPanel.SetActive(!isActive); // Đảo trạng thái của panel
        }
    }
}
