using UnityEngine;

//[CreateAssetMenu(menuName = "Game/Character Data", fileName = "CharacterData")]

[CreateAssetMenu(menuName = "Game/Level Data", fileName = "LevelData")]

public class LevelData : ScriptableObject
{
    [Header("ID")]
    public levels levelId;

    [Header("Atributes")]
    public int checkpoints;

    
}
