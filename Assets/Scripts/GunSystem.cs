using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public GameObject[] guns;

    void Start()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        guns[0].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseGun(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseGun(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseGun(2);
        }
    }

    void UseGun(int index)
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }

        guns[index].SetActive(true);
    }
}
