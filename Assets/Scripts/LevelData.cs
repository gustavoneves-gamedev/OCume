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
    public float checkpointDistance;
    public float bestHeight;
    public bool isUnlocked;
    //Acrescentar uma variável para determinar quando que o conjunto de prefabs será alterado IPC!!

    
}
