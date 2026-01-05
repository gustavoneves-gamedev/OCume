using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [CreateAssetMenu(menuName = "Game/Character Data", fileName = "CharacterData")]
    public class CharacterBaseData : ScriptableObject
    {
        [Header("ID")]
        public CharacterID characterID;

        [Header("Atributes")]
        public float baseMaxStamina;
        public float baseMovementSpeed;
        public float baseDamage;
        public float baseCooldown;
        public int baseAmmo;
        public float baseDefense;
        public float baseResistance;

    }
}
