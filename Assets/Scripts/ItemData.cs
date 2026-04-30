using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item Data", fileName = "ItemData")]

public class ItemData : ScriptableObject
{
    [Header("ID")]
    public ItemID characterID;

    [Header("Charges")]
    public int baseEffectCharges;
    public int baseEffectUpgradeLevel;
    public float baseChargeFactorUpgrade;
    public int baseEffectMaxLevel;
    public int[] coinChargeUpgradeCost;
    public int[] rubyChargeUpgradeCost;

    [Header("Duration")]
    public float baseDuration;
    public int durationUpgradeLevel;
    public float durationFactorUpgrade;
    public int durationMaxLevel;
    public int[] coinDurationUpgradeCost;
    public int[] rubyDurationUpgradeCost;

}
