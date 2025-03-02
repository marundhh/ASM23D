using UnityEngine;
using UnityEngine.UI;

public class AttributesManager : MonoBehaviour
{
    public static AttributesManager Instance { get; private set; }

    [Header("Attributes")]
    public int health;
    public int attack;
    public float critDamage = 1.5f;
    public float critChance = 0.5f;

    [Header("Audio Settings")]
    public AudioClip playerSlashSound; // Âm thanh khi player chém
    public AudioClip enemySlashSound;  // Âm thanh khi enemy chém
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (CompareTag("Player"))
        {
            GameSession.Instance.MaxHealth(health);
            GameSession.Instance.UpdateHealth(health);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        DamagePopUpGenerator.Current.CreatePopUp(transform.position, amount.ToString(), Color.yellow);

        if (CompareTag("Enemy"))
        {
            Slider slider = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
            slider.value = health;

            PlaySound(enemySlashSound);

            if (health <= 0) EnemyDie();
        }

        if (CompareTag("Player"))
        {
            GameSession.Instance.UpdateHealth(health);
            PlaySound(playerSlashSound);

            if (health <= 0) Time.timeScale = 0;
        }
    }

    public void EnemyDie()
    {
        Debug.Log("Kẻ thù đã chết");
        Animator ani = transform.GetChild(0).GetComponent<Animator>();
        ani.SetBool("isDead", true);

        transform.GetChild(1).gameObject.SetActive(false); // Ẩn canvas HP
        GetComponent<CapsuleCollider>().enabled = false;

        Invoke("DeactivateTpose", 2f);
        Invoke("ActivateGem", 2f);
        Destroy(gameObject, 10f);
    }

    void ActivateGem() => transform.GetChild(2).gameObject.SetActive(true);
    void DeactivateTpose() => transform.GetChild(0).gameObject.SetActive(false);

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            float totalDamage = attack;
            if (Random.Range(0f, 1f) < critChance) totalDamage += critDamage;

            atm.TakeDamage((int)totalDamage);

            if (CompareTag("Player")) PlaySound(playerSlashSound);
            if (CompareTag("Enemy")) PlaySound(enemySlashSound);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
