using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public WeaponSystem weaponSystem;
    public GameObject head;
    public float fireRange = 10;

    private GameObject[] targets;
    private Transform closestTarget = null;

    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= fireRange)
            {
                closestTarget = target.transform;
            }
        }

        if (closestTarget != null)
        {
            head.transform.LookAt(closestTarget);
            weaponSystem.ShootContinuously();
        }
    }
}
