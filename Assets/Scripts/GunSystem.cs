using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject craftBox;
    public GameObject craftBomb;

    void Start()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        guns[0].SetActive(true);
        craftBox.SetActive(false);
        craftBomb.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseGun(0);
            craftBox.SetActive(false);
            craftBomb.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseGun(1);
            craftBox.SetActive(false);
            craftBomb.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseGun(2);
            craftBox.SetActive(false);
            craftBomb.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            craftBox.SetActive(true);
            craftBomb.SetActive(false);
            foreach (GameObject gun in guns)
            {
                gun.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            craftBox.SetActive(false);
            craftBomb.SetActive(true);
            foreach (GameObject gun in guns)
            {
                gun.SetActive(false);
            }
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
