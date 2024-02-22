using UnityEngine;
using UnityEngine.InputSystem;

public class Gun2 : MonoBehaviour
{
    public WeaponSystem2 weaponSystem2;
    public InputActionReference shootActionReference; // Referencja do akcji



    void Start()
    {
       
        if (shootActionReference != null && shootActionReference.action != null)
        {
            shootActionReference.action.performed += _ => weaponSystem2.ShootContinuously();
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