using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCustomization : MonoBehaviour
{
    public TextMeshProUGUI player1ControlsText;
    public TextMeshProUGUI player2ControlsText;
    public GameObject player1LeftArrow;
    public GameObject player1RightArrow;
    public GameObject player2LeftArrow;
    public GameObject player2RightArrow;
    public TextMeshProUGUI player1Color;
    public TextMeshProUGUI player2Color;
    public GameObject player2Field;


    private void Start()
    {
        SetControlsToKeyboard(1);
        SetControlsToController(2);
    }

    public void PlayGame()
    {
        PlayerStatics.Player1Color = player1Color.text;
        PlayerStatics.Player2Color = player2Color.text;
        PlayerStatics.IsMultiplayer = player2Field.activeSelf;

        Debug.Log("Player 1 Controls: " + PlayerStatics.Player1Controls);
        Debug.Log("Player 1 Color: " + PlayerStatics.Player1Color);
        Debug.Log("Player 2 Color: " + PlayerStatics.Player2Color);
        Debug.Log("Is Multiplayer: " + PlayerStatics.IsMultiplayer);
        Debug.Log("Starting game...");

        SceneManager.LoadScene("GameScene");
    }

    public void ChangePlayer1Controls()
    {
        if(player1ControlsText.text == "Keyboard")
        {
            SetControlsToController(1);
            SetControlsToKeyboard(2);
            return;
        }

        if(player1ControlsText.text == "Controller")
        {
            SetControlsToKeyboard(1);
            SetControlsToController(2);
        }
    }

    public void ChangePlayer2Controls()
    {

        if(player2ControlsText.text == "Keyboard")
        {
            SetControlsToController(2);
            SetControlsToKeyboard(1);
            return;
        }

        if(player2ControlsText.text == "Controller")
        {
            SetControlsToKeyboard(2);
            SetControlsToController(1);
        }
    }

    private void SetControlsToKeyboard(int playerId)
    {
        if(playerId == 1)
        {
            PlayerStatics.Player1Controls = "Keyboard";
            player1ControlsText.text = "Keyboard";
            player1LeftArrow.SetActive(false);
            player1RightArrow.SetActive(true);
            return;
        }
        
        if(playerId == 2) 
        {
            PlayerStatics.Player1Controls = "Controller";
            player2ControlsText.text = "Keyboard";
            player2LeftArrow.SetActive(false);
            player2RightArrow.SetActive(true);
        }
    }

    private void SetControlsToController(int playerId)
    {
        if(playerId == 1)
        {
            PlayerStatics.Player1Controls = "Controller";
            player1ControlsText.text = "Controller";
            player1LeftArrow.SetActive(true);
            player1RightArrow.SetActive(false);
            return;
        }

        if (playerId == 2)
        {
            PlayerStatics.Player1Controls = "Keyboard";
            player2ControlsText.text = "Controller";
            player2LeftArrow.SetActive(true);
            player2RightArrow.SetActive(false);
        }
    }
}
