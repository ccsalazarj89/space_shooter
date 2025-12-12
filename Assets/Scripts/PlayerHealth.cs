using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Lifes")]
    public int maxLives = 3;
    private int currentLives;

    [Header("UI")]
    public Image[] hearts;

    // Update is called once per frame
    void Start()
    {
        currentLives = Mathf.Clamp(maxLives, 0, hearts.Length);
        UpdateHeartsUI();
    }

    public void TakeDamage()
    {
        if (currentLives <= 0) return;

        currentLives--;
        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }

}
