using System;
using TMPro;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public int damage = 10;
    public float range;
    public float fireRate;
    public float impactForce;
    private float nextTimeToFire = 0f;


    public GameObject source;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;
    private String playerLayer;

    public void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        bool isHit = Physics.Raycast(source.transform.position, source.transform.forward, out hit, range);

        if (isHit)
        {
            ParticleSystem impactInstance = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            impactInstance.Play();
            Destroy(impactInstance.gameObject, 2f);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage, playerLayer);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    public void ShootContinuously()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public void Start()
    {

        if (!LayerMask.LayerToName(transform.gameObject.layer).Equals("Turret") | !LayerMask.LayerToName(transform.gameObject.layer).Equals(null))
        {
            playerLayer = LayerMask.LayerToName(transform.parent.gameObject.layer);
        }

    }

}
