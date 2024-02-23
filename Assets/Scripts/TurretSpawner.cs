using UnityEngine;
using UnityEngine.InputSystem;

public class TurretSpawner : MonoBehaviour
{
    public PlayerEnergy playerEnergy;
    public GameObject turretPrefab;
    public int turretCost = 10;
    public InputActionAsset iaa;
    private InputAction ia;

    private void Start()
    {
        ia = iaa.FindAction("SpawnTurret");
        ia.performed += _ => TurretSpawn();
        ia.Enable();
    }

    private void TurretSpawn()
    {
        if (playerEnergy.currentEnergy >= turretCost)
        {
            Vector3 spawnPosition = transform.position + transform.right * 2f;
            spawnPosition.y = 0f + turretPrefab.transform.localScale.y / 2f;
            Instantiate(turretPrefab, spawnPosition, Quaternion.identity);
            playerEnergy.LoseEnergy(turretCost);
        }
    }

    // Usuniêto metodê OnTurretSpawn, poniewa¿ nie jest ju¿ potrzebna
}



