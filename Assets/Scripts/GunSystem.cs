using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject craftBox;
    public GameObject craftBomb;
    public WeaponSystem weapon;

    public InputActionAsset actionAsset; // Referencja do InputActionAsset

    private InputAction[] selectActions; // Tablica akcji dla wyboru broni

    void Start()
    {
        InitializeActions();
        SetAllInactive(); // Wy³¹cza wszystko na pocz¹tku
        ActivateItem(0); // Aktywuje pierwszy element jako domyœlny
    }

    void OnDestroy()
    {
        foreach (var action in selectActions)
        {
            action.Disable();
        }
    }

    void InitializeActions()
    {
        // Inicjalizacja i konfiguracja akcji
        selectActions = new InputAction[guns.Length + 2]; // +2 dla craftBox i craftBomb

        for (int i = 0; i < guns.Length; i++)
        {
            selectActions[i] = actionAsset.FindAction("Gun" + (i + 1));
            if (selectActions[i] != null)
            {
                int index = i; // Przechwytuj index w lokalnej zmiennej
                selectActions[i].performed += _ => ActivateItem(index);
            }
        }

        // Akcje dla craftBox i craftBomb
        selectActions[guns.Length] = actionAsset.FindAction("Gun4");
        if (selectActions[guns.Length] != null)
        {
            selectActions[guns.Length].performed += _ => ActivateCraftBox();
        }

        selectActions[guns.Length + 1] = actionAsset.FindAction("Gun5");
        if (selectActions[guns.Length + 1] != null)
        {
            selectActions[guns.Length + 1].performed += _ => ActivateCraftBomb();
        }
    }

    void ActivateItem(int index)
    {

        SetAllInactive();
        guns[index].SetActive(true);

        if (index == 0) {
            weapon.damage = 5;
            weapon.fireRate = 20;
            weapon.impactForce = 70;
            weapon.muzzleFlash.transform.localScale = Vector3.one;
        }

        if (index == 1)
        {
            weapon.damage = 15;
            weapon.fireRate = 30;
            weapon.impactForce = 100;
            weapon.muzzleFlash.transform.localScale *= 1.5f;
        }

        if (index == 2)
        {
            weapon.damage = 25;
            weapon.fireRate = 40;
            weapon.impactForce = 120;
            weapon.muzzleFlash.transform.localScale *= 3f;
        }


    }

    void ActivateCraftBox()
    {
        SetAllInactive();
        craftBox.SetActive(true);
        weapon.damage = 0;
        weapon.fireRate = 0;
        weapon.impactForce = 0;
    }

    void ActivateCraftBomb()
    {
        SetAllInactive();
        craftBomb.SetActive(true);
        weapon.damage = 0;
        weapon.fireRate = 0;
        weapon.impactForce = 0;
    }

    void SetAllInactive()
    {
        foreach (var gun in guns)
        {
            gun.SetActive(false);
            
        }
        craftBox.SetActive(false);
        craftBomb.SetActive(false);
    }

}
