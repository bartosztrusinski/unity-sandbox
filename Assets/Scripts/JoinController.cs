using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoiner : MonoBehaviour
{
    public GameObject playerPrefab;
    private PlayerInputManager playerInputManager;
    public InputActionAsset actionAsset; // Referencja do InputActionAsset

    private InputAction joinPlayerAction; // Akcja do³¹czania gracza
    public GameObject can;

    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();

        // Inicjalizacja akcji
        joinPlayerAction = actionAsset.FindAction("Join");
        if (joinPlayerAction != null)
        {
            joinPlayerAction.performed += _ => JoinPlayer();
            joinPlayerAction.Enable();
        }

        if (PlayerStatics.IsMultiplayer) {

            can.SetActive(true);

        }

    }

    private void OnDestroy()
    {
        // Wyrejestrowanie i wy³¹czenie akcji
        if (joinPlayerAction != null)
        {
            joinPlayerAction.Disable();
        }
    }

    private void JoinPlayer()
    {
        if (playerInputManager.playerCount < 2) // Mo¿esz zmieniæ warunek w razie potrzeby

            playerInputManager.JoinPlayer();
            can.SetActive(true);
            PlayerStatics.IsMultiplayer = true;
        }
    }
