using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // Pr�dko�� obrotu postaci

    void Update()
    {
        // Pobieranie wej�cia od u�ytkownika
        float horizontalInput = Input.GetAxis("Horizontal2");

        // Obliczanie k�ta obrotu wok� osi Y
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        // Obracanie postaci wok� osi Y
        transform.Rotate(0, rotation, 0);
    }
}