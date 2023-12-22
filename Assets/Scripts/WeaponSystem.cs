using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    private float nextTimeToFire = 0f;


    public GameObject source;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;

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
                target.TakeDamage(damage);
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
}
