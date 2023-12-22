using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public PlayerEnergy playerEnergy;
    public GameObject turretPrefab;
    public int turretCost = 30;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerEnergy.currentEnergy >= turretCost)
            {
                Vector3 spawnPosition = transform.position + transform.right * 2f;
                spawnPosition.y = 0f + turretPrefab.transform.localScale.y / 2f;
                Instantiate(turretPrefab, spawnPosition, Quaternion.identity);

                playerEnergy.LoseEnergy(turretCost);
            }
        }
    }
}
