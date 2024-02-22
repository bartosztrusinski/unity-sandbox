using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    public static int playerKills1;
    public static int playerKills2;

    public TextMeshProUGUI myTextMesh1;
    public TextMeshProUGUI myTextMesh2;


    // Start is called before the first frame update
    void Start()
    {
        playerKills1 = 0;
        playerKills2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        myTextMesh1.text = playerKills1.ToString();
        myTextMesh2.text = playerKills2.ToString();
    }
}
