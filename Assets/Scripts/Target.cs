using System.Collections;
using TMPro;
using UnityEngine;


public class Target : MonoBehaviour
{
    public HealthBar healthBar;
    public SpawnPoints spawnPoints;
    public Animator targetAnimator;
    public Transform cam;

    public int maxHealth = 100;
    public enum DeathType { Respawn, Teleport, Die };
    public DeathType deathType = DeathType.Die;

    private int health;
    private bool isDying;
    private float deathAnimationLength;
    private GameObject currentPoint;

    private readonly string HIT_ANIMATION = "GetHit";
    private readonly string DIE_ANIMATION = "Die";
    public PlayerCounter playerCounter;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        deathAnimationLength = targetAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }

    public void TakeDamage(int amount, string layer)
    {
        if (isDying)
        {
            return;

        }

   

        targetAnimator.Play(HIT_ANIMATION);
        SetHealth(health - amount);

        if (health <= 0f)
        {
            switch (deathType)
            {
                case DeathType.Respawn:
                    StartCoroutine(Respawn());
                    playerCount(layer);
                    break;
                case DeathType.Teleport:
                    StartCoroutine(Teleport());
                    playerCount(layer);
                    break;
                case DeathType.Die:
                    Die();
                    playerCount(layer);
                    break;
            }
        }
    }

    private void SetHealth(int amount)
    {
        health = amount;
        healthBar.SetHealth(health);
    }

    public void playerCount(string layer) {

        if (layer.Equals("Player") | layer.Equals("Bomb")) {

            PlayerCounter.playerKills1++;

        }

        if (layer.Equals("Player2"))
        {
            PlayerCounter.playerKills2++;
        }

    }


    private void Die()
    {
        isDying = true;
        targetAnimator.Play(DIE_ANIMATION);

        Destroy(healthBar.gameObject);
        Destroy(gameObject, deathAnimationLength);
    }

    private IEnumerator Respawn()
    {
        isDying = true;
        targetAnimator.Play(DIE_ANIMATION);
        healthBar.Hide();

        yield return new WaitForSeconds(deathAnimationLength);

        isDying = false;
        SetHealth(maxHealth);
        healthBar.Show();
    }

    private IEnumerator Teleport()
    {
        isDying = true;
        targetAnimator.Play(DIE_ANIMATION);
        healthBar.Hide();

        yield return new WaitForSeconds(0.7f);

        gameObject.SetActive(false);

        isDying = false;
        SetHealth(maxHealth);
        healthBar.Show();

        spawnPoints.FreeSpawnPoint(currentPoint);
        currentPoint = spawnPoints.GetRandomSpawnPoint();
        transform.position = currentPoint.transform.position;
        transform.LookAt(transform.position - cam.forward);

        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            TakeDamage(30, "Bomb");
        }
    }
}
