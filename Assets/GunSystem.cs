using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public GameObject[] guns;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        guns[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (GameObject gun in guns)
            {
                gun.SetActive(false);
            }
            guns[0].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (GameObject gun in guns)
            {
                gun.SetActive(false);
            }
            guns[1].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (GameObject gun in guns)
            {
                gun.SetActive(false);
            }
            guns[2].SetActive(true);
        }
    }
}
