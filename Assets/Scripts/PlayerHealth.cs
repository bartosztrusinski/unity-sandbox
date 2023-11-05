using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;

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
}
