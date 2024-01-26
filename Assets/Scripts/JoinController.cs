using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoiner : MonoBehaviour
{
    public GameObject playerPrefab;
    private PlayerInputManager playerInputManager;
    public InputActionAsset actionAsset; // Referencja do InputActionAsset

    private InputAction joinPlayerAction; // Akcja do��czania gracza

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

    }

    private void OnDestroy()
    {
        // Wyrejestrowanie i wy��czenie akcji
        if (joinPlayerAction != null)
        {
            joinPlayerAction.Disable();
        }
    }

    private void JoinPlayer()
    {
        if (playerInputManager.playerCount < 2) // Mo�esz zmieni� warunek w razie potrzeby

            playerInputManager.JoinPlayer();
        }
    }
