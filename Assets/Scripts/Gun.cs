using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        bool isHit = Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range);

        if(isHit)
        {
            ParticleSystem impactInstance = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            impactInstance.Play();
            Destroy(impactInstance.gameObject, 2f);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
