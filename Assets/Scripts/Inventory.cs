using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Shield")]
    public int shieldDurationUpgrade = 0;
    public float shieldFactor = 10f;
    public int shieldChargeUpgrade = 1;
    
    [Header("Stamina Potion")]
    public int staminaPotionUpgrade = 0;
    public float staminaPotionUpgradeFactor = 10f;

    [Header("Coin Multiplier")]
    public int coinDurationUpgrade = 0;
    public float coinUpgradeFactor = 5f;
    public int coinChargeUpgrade = 1;


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

    #region Potion Upgrade

    public void PotionUpgrade()
    {
        staminaPotionUpgrade++;
    }

    #endregion

    #region Coin Multiplier



    #endregion

    #endregion
}
