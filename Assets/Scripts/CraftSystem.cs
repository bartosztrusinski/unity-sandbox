using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    private GameObject objectToCreate;
    public Camera cam;
    public GameObject prefabBox;
    public GameObject prefabBoxGhost;
    public LayerMask groundLayer;
    public LayerMask objectLayer; 
    private float gridSize = 1.3f; 
    public Color defaultColor = Color.white; 
    private Color blockedColor = Color.red; 
    private List<GameObject> createdObjects = new List<GameObject>();
    private List<GameObject> createdGhost = new List<GameObject>();
    public PlayerEnergy pe;
    public GameObject crosshair;




    void Start()
    {
        objectToCreate = Instantiate(prefabBoxGhost, Vector3.zero, Quaternion.identity);
        createdGhost.Add(objectToCreate);
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Ray ray2 = cam.ScreenPointToRay(crosshair.transform.position);
        RaycastHit hit;
        if (PlayerStatics.IsMultiplayer)
        {
            if (Physics.Raycast(ray2, out hit, Mathf.Infinity, groundLayer | objectLayer))
            {
                Vector3 objectPos = hit.point;
                objectPos = AlignToGrid(objectPos);
                bool canCreateObject = true;

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Box1") | pe.currentEnergy <= 10)
                {
                    ChangeColor(objectToCreate, blockedColor);
                    canCreateObject = false;
                }
                else
                {
                    ChangeColor(objectToCreate, defaultColor);
                    canCreateObject = true;
                }

                if (canCreateObject && (!(hit.collider.gameObject.layer == LayerMask.NameToLayer("Box1"))))
                {
                    objectPos += Vector3.up * 0.5f;

                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject newObject = Instantiate(prefabBox, objectPos, Quaternion.identity);
                        createdObjects.Add(newObject);
                        pe.LoseEnergy(10);
                    }
                }


                objectToCreate.transform.position = objectPos + Vector3.up * 0.5f;


            }
        }
        else {

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer | objectLayer))
            {
                Vector3 objectPos = hit.point;
                objectPos = AlignToGrid(objectPos);
                bool canCreateObject = true;

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Box1") | pe.currentEnergy <= 10)
                {
                    ChangeColor(objectToCreate, blockedColor);
                    canCreateObject = false;
                }
                else
                {
                    ChangeColor(objectToCreate, defaultColor);
                    canCreateObject = true;
                }

                if (canCreateObject && (!(hit.collider.gameObject.layer == LayerMask.NameToLayer("Box1"))))
                {
                    objectPos += Vector3.up * 0.5f;

                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject newObject = Instantiate(prefabBox, objectPos, Quaternion.identity);
                        createdObjects.Add(newObject);
                        pe.LoseEnergy(10);
                    }
                }


                objectToCreate.transform.position = objectPos + Vector3.up * 0.5f;


            }

        }


    }

    private Vector3 AlignToGrid(Vector3 position)
    {
        position /= gridSize;
        position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), Mathf.Round(position.z));
        position *= gridSize;
        return position;
    }

    void ChangeColor(GameObject objectToChange, Color color)
    {

        Renderer[] renderers = objectToChange.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            foreach (Material mat in r.materials)
            {
                mat.color = color;
                mat.SetColor("_ColorTint", color);
            }
        }
    }

    private void OnDisable()
    {
        foreach (GameObject g in createdGhost) {
            g.SetActive(false);
        }
    }

    private void OnEnable()
    {
        foreach (GameObject g in createdGhost)
        {
            g.SetActive(true);
        }
    }

}