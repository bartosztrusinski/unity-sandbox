using UnityEngine;
using UnityEngine.EventSystems;

public class MenuBehavior : MonoBehaviour
{

    public GameObject playMenuButton;
    public GameObject mainMenuButton;
    public GameObject creditsButton;
    public GameObject settingsButton;
    public GameObject exitModalButton;

    

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnMainMenuFocus()
    {
        EventSystem.current.SetSelectedGameObject(mainMenuButton);
    }

    public void OnPlayMenuOpen()
    {
        EventSystem.current.SetSelectedGameObject(playMenuButton);
    }

    public void OnCreditsOpen()
    {
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    public void OnSettingsOpen()
    {
        EventSystem.current.SetSelectedGameObject(settingsButton);
    }

    public void OnExitModalOpen()
    {
        EventSystem.current.SetSelectedGameObject(exitModalButton);
    }
}
