using TMPro;
using UnityEngine;

public class PlayerColors : MonoBehaviour
{
    public GameObject redColor;
    public GameObject blueColor;
    public GameObject greenColor;
    public GameObject prevArrow;
    public GameObject nextArrow;
    public TextMeshProUGUI currentColor;

    private void Start()
    {
        currentColor.text = "Red";
        blueColor.SetActive(false);
        greenColor.SetActive(false);
        prevArrow.SetActive(false);
    }
    
    public void SetNextColor()
    {
        if (redColor.activeSelf)
        {
            SetBlueColor();
            return;
        }

        if (blueColor.activeSelf)
        {
            SetGreenColor();
        }
    }

    public void SetPreviousColor()
    {
        if(blueColor.activeSelf)
        {
            SetRedColor();
            return;
        }

        if(greenColor.activeSelf)
        {
            SetBlueColor();
        }
    }

    private void SetRedColor()
    {
        currentColor.text = "Red";
        redColor.SetActive(true);
        blueColor.SetActive(false);
        prevArrow.SetActive(false);
    }

    private void SetBlueColor()
    {
        currentColor.text = "Blue";
        blueColor.SetActive(true);
        redColor.SetActive(false);
        greenColor.SetActive(false);
        prevArrow.SetActive(true);
        nextArrow.SetActive(true);
    }

    private void SetGreenColor()
    {
        currentColor.text = "Green";
        greenColor.SetActive(true);
        blueColor.SetActive(false);
        nextArrow.SetActive(false);
    }
}
