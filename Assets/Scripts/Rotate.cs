using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotation;
    public float speed = 1f;

    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime, Space.Self);
    }
}
