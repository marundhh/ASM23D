using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttributesManager : MonoBehaviour
{
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
            FindFirstObjectByType<GameSession>().MaxHealth(health);
            FindFirstObjectByType<GameSession>().UpdateHealth(health);
        }
    }

    public void TackeDamage(int amount)
    {
        health -= amount;
        DamagePopUpGenerator.Current.CreatePopUp(transform.position, amount.ToString(), Color.yellow);

        if (CompareTag("Enemy"))
        {
            Slider slider = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
            slider.value = health;

            PlaySound(enemySlashSound); // Phát âm khi Enemy bị chém

            if (health <= 0) EnemyDie();
        }

        if (CompareTag("Player"))
        {
            FindFirstObjectByType<GameSession>().UpdateHealth(health);
            PlaySound(playerSlashSound); // Phát âm khi Player bị Enemy chém

            if (health <= 0) Time.timeScale = 0; // Player chết
        }
    }
   
    public void EnemyDie()
    {
        Debug.Log("kẻ thù chết");
        Animator ani = transform.GetChild(0).GetComponent<Animator>();
        ani.SetBool("isDead", true);

        transform.GetChild(1).gameObject.SetActive(false); // Ẩn canvas HP
        GetComponent<CapsuleCollider>().enabled = false;

        Invoke("DeActiveTpose", 2f);
        Invoke("ActiveGem", 2f);
        Destroy(gameObject, 10f);
    }

    void ActiveGem() => transform.GetChild(2).gameObject.SetActive(true);
    void DeActiveTpose() => transform.GetChild(0).gameObject.SetActive(false);

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            float totalDamage = attack;
            if (Random.Range(0f, 1f) < critChance) totalDamage += critDamage;

            atm.TackeDamage((int)totalDamage); // Gây sát thương

            if (CompareTag("Player")) PlaySound(playerSlashSound); // Player chém
            if (CompareTag("Enemy")) PlaySound(enemySlashSound);   // Enemy chém
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
