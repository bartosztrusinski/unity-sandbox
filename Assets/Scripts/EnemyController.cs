using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencja do obiektu gracza
    [SerializeField] private NavMeshAgent agent; // Komponent agenta nawigacji

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Pobranie komponentu NavMeshAgent
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // Ustawienie celu na pozycjê gracza
        }
    }


}