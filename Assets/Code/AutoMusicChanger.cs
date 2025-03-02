using UnityEngine;

public class AutoMusicChanger : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource phát nhạc
    public AudioClip[] playlist;    // Danh sách bài hát
    private int currentTrackIndex = 0;
    private float timer = 0f;
    private float switchTime = 10f; // Thời gian mỗi bài (10 giây)

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Tự động lấy AudioSource nếu chưa gán
        }

        if (playlist.Length > 0)
        {
            PlayTrack(currentTrackIndex);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime) // Nếu đã đủ 10 giây
        {
            NextTrack();
        }
    }

    void PlayTrack(int index)
    {
        if (playlist.Length == 0) return;

        audioSource.clip = playlist[index];
        audioSource.Play();
        timer = 0f; // Reset bộ đếm
    }

    void NextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length; // Chuyển bài
        PlayTrack(currentTrackIndex);
    }
}
