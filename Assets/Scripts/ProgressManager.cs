using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager progressManager;

    [Header("Stat Upgrades")]
    public float staminaIncrement;
    public float movementSpeedIncrement;
    public float damageIncrement;
    public float cooldownIncrement;
    public int ammoIncrement;
    public float defenseIncrement;
    public float resistanceIncrement;


    [Header("Cowboy Stat Upgrades")]
    public float cowboyStaminaUpgradeFactor = 5f;
    public int cowboyStaminaUpgrades;
    public float cowboyMovementSpeedUpgradeFactor = 1f;
    public int cowboyMovementSpeedUpgrades;
    public float cowboyDamageUpgradeFactor = 1f;
    public int cowboyDamageUpgrades;
    public float cowboyCooldownUpgradeFactor = 0.2f;
    public int cowboyCooldownUpgrades;
    public int cowboyAmmoUpgradeFactor = 1;
    public int cowboyAmmoUpgrades;
    public float cowboyDefenseUpgradeFactor = 5f;
    public int cowboyDefenseUpgrades;
    public float cowboyResistanceUpgradeFactor = 2f;
    public int cowboyResistanceUpgrades;



    private void Awake()
    {
        if (progressManager == null)
            progressManager = this;
        else
            Destroy(gameObject);
    }

    public void UpgradeCharacter(characterID character, statType stat)
    {
        if (character == characterID.Cowboy)
            UpgradeCowboy(stat);

        //DEIXEI AQUI PARA PREPARAR NO FUTURO CASO O DO COWBOY DÊ CERTO!!!
        //if (character == characterID.Samurai)
        //    UpgradeSamurai(stat);

        //if (character == characterID.Alpinista)
        //    UpgradeAlpinista(stat);
    }

    private void UpgradeCowboy(statType stat)
    {
        if (stat == statType.Stamina) cowboyStaminaUpgrades++;
        if (stat == statType.MovementSpeed) cowboyMovementSpeedUpgrades++;
        if (stat == statType.Damage) cowboyDamageUpgrades++;
        if (stat == statType.Cooldown) cowboyCooldownUpgrades++;
        if (stat == statType.Ammo) cowboyAmmoUpgrades++;
        if (stat == statType.Defense) cowboyDefenseUpgrades++;
        if (stat == statType.Resistance) cowboyResistanceUpgrades++;

    }

}
