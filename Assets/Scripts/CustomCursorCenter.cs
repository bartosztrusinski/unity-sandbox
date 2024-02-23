using UnityEngine;

public class CustomCursorCenter : MonoBehaviour
{
    public Camera myCamera; // referencja do kamery
    public RectTransform customCursorImage; // referencja do niestandardowego kursora

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Oblicz �rodek widoku kamery
        Vector3 cameraCenter = myCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, myCamera.nearClipPlane));

        // Aktualizuj pozycj� niestandardowego kursora
        customCursorImage.position = cameraCenter;
    }
}
