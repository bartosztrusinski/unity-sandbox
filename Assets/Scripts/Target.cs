using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 100;
    public HealthBar healthBar;
    public Animator targetAnimator;

    private bool isDying;

    void Start()
    {
        healthBar.SetMaxHealth(health);
    }

    public void TakeDamage(int amount)
    {
        if (isDying)
        {
            return;
        }

        targetAnimator.Play("GetHit");

        health -= amount;
        healthBar.SetHealth(health);

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        isDying = true;

        targetAnimator.Play("Die");

        float deathAnimationLength = targetAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Destroy(healthBar.gameObject);
        Destroy(gameObject, deathAnimationLength);
    }
}
