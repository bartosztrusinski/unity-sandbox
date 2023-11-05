using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int enterDamage = 10;
    public int tickDamage = 1;

    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.CompareTag("Obstacle"))
        {
            playerHealth.TakeDamage(enterDamage);
        }
    }

    private void OnTriggerStay(Collider obstacle)
    {
        if (obstacle.gameObject.CompareTag("Obstacle"))
        {
            playerHealth.TakeDamage(tickDamage);
        }
    }
}
