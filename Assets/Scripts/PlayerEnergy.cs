using TMPro;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public EnergyBar energyBar;
    public TextMeshProUGUI energy;

    public int maxEnergy = 100;
    public int currentEnergy;

    void Start()
    {
        energyBar.SetMaxEnergy(maxEnergy);
        energyBar.SetEnergy(currentEnergy);
    }

    public void LoseEnergy(int energy)
    {
        currentEnergy -= energy;
        energyBar.SetEnergy(currentEnergy);
    }

    public void GainEnergy(int energy)
    {
        currentEnergy += energy;
        energyBar.SetEnergy(currentEnergy);
        if (currentEnergy > 100) {
            currentEnergy = 100;
        }
    }

    public void Update()
    {
        energy.text = currentEnergy.ToString();
    }

}
