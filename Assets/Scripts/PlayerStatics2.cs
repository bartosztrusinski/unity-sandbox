using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatics2: MonoBehaviour
{

    public Texture txtRed;
    public Texture txtBlue;
    public Texture txtGreen;
    public GameObject player1;
    public InputActionAsset join;
    private PlayerInputManager pim;



    public static string Player1Controls { get; set; }
    public static string Player2Color { get; set; }


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

         if (Player2Color.Equals("Red")) {
            BaseMapChange(player1, txtRed);
        } else
        {
            if (Player2Color.Equals("Blue"))
            {
                BaseMapChange(player1,txtBlue);
            }
            else {
                BaseMapChange(player1,txtGreen);
            }
        }
        






    }


}
