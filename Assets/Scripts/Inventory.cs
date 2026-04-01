using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Stamina Potion")]
    public int staminaPotionUpgrade;
    public float staminaPotionUpgradeFactor = 10f;

    [Header("Shield")]
    public int shieldDurationUpgrade = 0;
    public float shieldFactor = 10f;
    public int shieldChargeUpgrade = 1;


    void Start()
    {
        GameController.gameController.inventory = this;
        InitializeItemsUpgrades();
    }

    private void InitializeItemsUpgrades()
    {
        
    }


    #region Item Upgrades

    #region Shield Upgrades

    public void UpgradeShieldDuration()
    {
        shieldDurationUpgrade++;        
    }

    public void UpgradeShieldCharges()
    {
        shieldChargeUpgrade++;
    }

    #endregion

    #endregion
}
