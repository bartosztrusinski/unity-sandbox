using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public ParticleSystem explosion;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ParticleSystem x = Instantiate(explosion, Vector3.zero, Quaternion.identity);
            x.transform.position = transform.position;
            x.Play();
            Destroy(this.gameObject, 1f);
            Destroy(x, 1f);
        }
    }
}
