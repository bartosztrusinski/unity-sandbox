using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem2 : MonoBehaviour
{
    public GameObject[] guns;
    public WeaponSystem2 weapon;

    public InputActionAsset actionAsset; // Referencja do InputActionAsset
    public GameObject[] imgs;


    private int gunCounter = 0;

    void Start()
    {

        InitializeActions();
        SetAllInactive(); // Wy��cza wszystko na pocz�tku
        ActivateItem(0); // Aktywuje pierwszy element jako domy�lny
        imgs[0].SetActive(true);
    }


    void InitializeActions()
    {
        var selectAction = actionAsset.FindAction("Select");
        if (selectAction != null)
        {
            selectAction.performed += _ => testFunction();
        }
    }

    void testFunction() {


        gunCounter++;
        if (gunCounter == 3) {

            gunCounter = 0;

        }

        if (gunCounter < 3) {
            ActivateItem(gunCounter);
        }
    }

    void ActivateItem(int index)
    {

        SetAllInactive();
        guns[index].SetActive(true);

        if (index == 0)
        {
            weapon.damage = 5;
            weapon.fireRate = 20;
            weapon.impactForce = 70;
            weapon.muzzleFlash.transform.localScale = Vector3.one;
            imgs[0].SetActive(true);
        }

        if (index == 1)
        {
            weapon.damage = 15;
            weapon.fireRate = 30;
            weapon.impactForce = 100;
            weapon.muzzleFlash.transform.localScale *= 1.5f;
            imgs[1].SetActive(true);
        }

        if (index == 2)
        {
            weapon.damage = 25;
            weapon.fireRate = 40;
            weapon.impactForce = 120;
            weapon.muzzleFlash.transform.localScale *= 3;
            imgs[2].SetActive(true);
        }


    }

    void SetAllInactive()
    {
        foreach (var gun in guns)
        {
            gun.SetActive(false);

        }

        for (int i = 0; i < 3; i++) {
            imgs[i].SetActive(false);
        }


    }

}
