using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatics: MonoBehaviour
{

    public Texture txtRed;
    public Texture txtBlue;
    public Texture txtGreen;
    public GameObject player1;
    //public GameObject player2;
    public InputActionAsset join;
    private InputAction myAction;
    private PlayerInputManager pim;



    public static string Player1Controls { get; set; }
    public static string Player1Color { get; set; }
    public static string Player2Color { get; set; }
    public static bool IsMultiplayer { get; set; }

    void BaseMapChange(GameObject player, Texture txt) {

        Renderer renderer = player.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = renderer.material;
            mat.SetTexture("_BaseMap", txt); // Ustawienie nowej tekstury
        }

    }

    private void Start()
    {

        Debug.Log(IsMultiplayer);

        if (IsMultiplayer)
        {

            pim = FindObjectOfType<PlayerInputManager>();
            pim.JoinPlayer();


        }


         if (Player1Color.Equals("Red")) {
            BaseMapChange(player1, txtRed);
        } else
        {
            if (Player1Color.Equals("Blue"))
            {
                BaseMapChange(player1,txtBlue);
            }
            else {
                BaseMapChange(player1,txtGreen);
            }
        }
        /*
        if (Player2Color.Equals("Red"))
        {
            BaseMapChange(player2, txtRed);
        }
        else
        {
            if (Player2Color.Equals("Blue"))
            {
                BaseMapChange(player2, txtBlue);
            }
            else
            {
                BaseMapChange(player2, txtGreen);
            }
        } */





    }


}
