using UnityEngine;
using UnityEngine.InputSystem;

public class TurretSpawner : MonoBehaviour
{
    public PlayerEnergy playerEnergy;
    public GameObject turretPrefab;
    public int turretCost = 30;
    private bool isTurretSpawn = false;


    public void OnTurretSpawn(InputAction.CallbackContext context)
    {
        isTurretSpawn = true;
    }


    void Update()
    {
        if (isTurretSpawn)
        {
            isTurretSpawn = false;
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
