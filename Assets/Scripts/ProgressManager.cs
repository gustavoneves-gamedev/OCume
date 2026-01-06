using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager progressManager;

    [Header("Cowboy")]
    public float staminaUpgradeFactor = 5f;
    public int staminaUpgrades;
    public float movementSpeedUpgradeFactor = 1f;
    public int movementSpeedUpgrades;
    public float damageUpgradeFactor = 1f;
    public int damageUpgrades;
    public float cooldownUpgradeFactor = 0.2f;
    public int cooldownUpgrades;
    public int ammoUpgradeFactor = 1;
    public int ammoUpgrades;
    public float defenseUpgradeFactor = 5f;
    public int defenseUpgrades;
    public float resistanceUpgradeFactor = 2f;
    public int resistanceUpgrades;

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
        if (stat == statType.Stamina) staminaUpgrades++;
        if (stat == statType.MovementSpeed) movementSpeedUpgrades++;
        if (stat == statType.Damage) damageUpgrades++;
        if (stat == statType.Cooldown) cooldownUpgrades++;
        if (stat == statType.Ammo) ammoUpgrades++;
        if (stat == statType.Defense) defenseUpgrades++;
        if (stat == statType.Resistance) resistanceUpgrades++;

    }
    
}
