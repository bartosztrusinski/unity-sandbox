using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public EnergyBar energyBar;

    public int maxEnergy = 100;
    public int currentEnergy;

    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UseEnergy(20);
        }
    }

    void UseEnergy(int energy)
    {
        currentEnergy -= energy;
        energyBar.SetEnergy(currentEnergy);
    }
}
