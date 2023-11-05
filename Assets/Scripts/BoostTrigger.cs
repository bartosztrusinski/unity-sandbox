using UnityEngine;

public class BoostTrigger : MonoBehaviour
{
    public PlayerEnergy playerEnergy;
    public int energyBoost = 10;

    private void OnTriggerEnter(Collider boost)
    {
        if (boost.gameObject.CompareTag("Boost"))
        {
            playerEnergy.GainEnergy(energyBoost);
            Destroy(boost.gameObject);
        }
    }
}
