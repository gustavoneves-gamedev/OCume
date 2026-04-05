using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Shield")]
    public int shieldDurationUpgrade = 0;
    public float shieldUpgradeFactor = 10f;
    public int shieldChargeUpgrade = 1;
    
    [Header("Stamina Potion")]
    public int staminaPotionUpgrade = 0;
    public int staminaPotionUpgradeFactor = 5;
    public int staminaPotionUpgradeCost = 100;

    [Header("Coin Multiplier")]
    public int coinDurationUpgrade = 0;
    public float coinDurationUpgradeFactor = 8f;
    public int coinMultiplierUpgrade = 0;
    public float coinMultiplierUpgradeFactor = 1f;

    void Start()
    {
        GameController.gameController.inventory = this;
        Invoke("InitializeItemsUpgrades", .2f);
    }

    private void InitializeItemsUpgrades()
    {
        //STAMINA POTION
        //Inserir aqui a puxada de informações do script onde estarão as informações da poção
        UIStaminaPotionUpdate();
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
        staminaPotionUpgradeCost *= staminaPotionUpgrade * (3 + staminaPotionUpgrade);

        UIStaminaPotionUpdate();
    }

    private void UIStaminaPotionUpdate()
    {
        GameController.gameController.uiController.
            UpdateStaminaPostionUpgradeUI((staminaPotionUpgrade * staminaPotionUpgradeFactor),
            staminaPotionUpgrade, staminaPotionUpgradeCost);
    }

    #endregion

    #region Coin Multiplier

    public void UpgradeCoinDuration()
    {
        coinDurationUpgrade++;
    }

    public void UpgradeCoinMultiplier()
    {
        coinMultiplierUpgrade++;
    }

    #endregion

    #endregion
}
