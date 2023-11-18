using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject[] spawnPoints;

    private bool[] pointsOccupied;

    private void Start()
    {
        pointsOccupied = new bool[spawnPoints.Length];
        for(int i = 0; i < pointsOccupied.Length; i++)
        {
            pointsOccupied[i] = false;
        }
    }

    public GameObject GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (!pointsOccupied[randomIndex])
            {
                pointsOccupied[randomIndex] = true;
                return spawnPoints[randomIndex];
            }

            randomIndex = (randomIndex + 1) % spawnPoints.Length;
        }

        return null;
    }

    public void FreeSpawnPoint(GameObject spawnPoint)
    {
        for (int i = 0; i < pointsOccupied.Length; i++)
        {
            if (spawnPoints[i] == spawnPoint)
            {
                pointsOccupied[i] = false;
                return;
            }
        }
    }

    public int GetLength()
    {
        return spawnPoints.Length;
    }
}
