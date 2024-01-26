using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public string playerTag = "Player"; // Tag, kt�rym s� oznaczeni gracze
    [SerializeField] private NavMeshAgent agent; // Komponent agenta nawigacji

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Pobranie komponentu NavMeshAgent
    }

    void Update()
    {
        // Znajd� wszystkie obiekty z tagiem playerTag
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        // Sprawd�, czy istniej� jakiekolwiek obiekty z tym tagiem
        if (players.Length > 0)
        {
            Transform closestPlayer = FindClosestPlayer(players);
            if (closestPlayer != null)
            {
                agent.SetDestination(closestPlayer.position); // Ustawienie celu na pozycj� najbli�szego gracza
            }
        }
    }

    Transform FindClosestPlayer(GameObject[] players)
    {
        Transform closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (GameObject player in players)
        {
            float distToPlayer = Vector3.Distance(player.transform.position, currentPos);
            if (distToPlayer < minDistance)
            {
                closest = player.transform;
                minDistance = distToPlayer;
            }
        }

        return closest;
    }
}
