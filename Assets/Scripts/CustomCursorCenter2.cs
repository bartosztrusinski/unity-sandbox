using UnityEngine;

public class CustomCursorCenter2 : MonoBehaviour
{
    public Camera myCamera; // referencja do kamery
    public RectTransform customCursorImage; // referencja do niestandardowego kursora

    private void Start()
    {
        GameObject gameObject = GameObject.Find("Crosshair2");
        customCursorImage = gameObject.GetComponent<RectTransform>();

    }

    private void Update()
    {
        // Oblicz œrodek widoku kamery
        Vector3 cameraCenter = myCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, myCamera.nearClipPlane));

        // Aktualizuj pozycjê niestandardowego kursora
        customCursorImage.position = cameraCenter;
    }
}
