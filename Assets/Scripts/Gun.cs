using UnityEngine;

public class Gun : MonoBehaviour
{
    public WeaponSystem weaponSystem;
    public string shootButton = "Fire1";

    void Update()
    {
        if (Input.GetButton(shootButton)) { 
            weaponSystem.ShootContinuously();
        }
    }
}
