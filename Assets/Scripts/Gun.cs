using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public WeaponSystem weaponSystem;
    public InputActionReference shootActionReference; // Referencja do akcji



    void Start()
    {

        if (shootActionReference != null && shootActionReference.action != null)
        {
            shootActionReference.action.performed += _ => weaponSystem.ShootContinuously();
            shootActionReference.action.Enable();
        }
    }

    void OnDestroy()
    {
        // Wyrejestrowanie zdarzeñ
        if (shootActionReference != null && shootActionReference.action != null)
        {
            shootActionReference.action.Disable();
        }
    }
}