using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 100;
    public HealthBar healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(health);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
