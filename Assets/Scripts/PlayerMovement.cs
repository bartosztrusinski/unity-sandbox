using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // Prêdkoœæ obrotu postaci

    void Update()
    {
        // Pobieranie wejœcia od u¿ytkownika
        float horizontalInput = Input.GetAxis("Horizontal2");

        // Obliczanie k¹ta obrotu wokó³ osi Y
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        // Obracanie postaci wokó³ osi Y
        transform.Rotate(0, rotation, 0);
    }
}