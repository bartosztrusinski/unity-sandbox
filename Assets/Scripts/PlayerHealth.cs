using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI health;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    public void Update()
    {
        health.text = currentHealth.ToString();

        if (currentHealth <= 0) {
            Time.timeScale = 0;
        }

    }


}
