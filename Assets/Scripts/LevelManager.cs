using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private GameObject[] cowboyLevelPrefabs;
    [SerializeField] private Transform startSpawn;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.levelManager = this;
        
        Instantiate(cowboyLevelPrefabs[0], startSpawn.position, startSpawn.rotation);
    }

    
}
