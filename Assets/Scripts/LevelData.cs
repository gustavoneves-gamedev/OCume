using UnityEngine;

//[CreateAssetMenu(menuName = "Game/Character Data", fileName = "CharacterData")]

[CreateAssetMenu(menuName = "Game/Level Data", fileName = "LevelData")]

public class LevelData : ScriptableObject
{
    [Header("ID")]
    public levelID levelId;

    [Header("Atributes")]
    public int checkpoints;
    public int currentCheckpoint;
    //public float checkpointDistance;
    public float height;
    public bool isUnlocked;

    
}
