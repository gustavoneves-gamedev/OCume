using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private GameObject[] cowboyLevelPrefabs;
    [SerializeField] private Transform startSpawn;
    private GameObject currentLevelPrefab;
    private GameObject lastLevelPrefab;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.levelManager = this;

        currentLevelPrefab = Instantiate(cowboyLevelPrefabs[0].gameObject, startSpawn.position, startSpawn.rotation);

    }

    public void SpawnLevelPrefab()
    {
        GameObject newLevelPrefab = Instantiate(cowboyLevelPrefabs[0], 
            currentLevelPrefab.GetComponent<LevelRoot>().levelPrefabSpawnPoint.position, startSpawn.rotation);

        lastLevelPrefab = currentLevelPrefab;

        currentLevelPrefab = newLevelPrefab;
    }

    public void DestroyLevelPrefab()
    {
        Destroy(lastLevelPrefab);
    }

}
