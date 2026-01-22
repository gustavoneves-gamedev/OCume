using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header(" Cowboy Level")]
    [SerializeField] private GameObject[] cowboyLevelPrefabsA;
    [SerializeField] private GameObject[] cowboyLevelPrefabsB;
    [SerializeField] private GameObject[] cowboyLevelPrefabsC;
    [SerializeField] private GameObject[] cowboyLevelPrefabsD;

    [Header(" Samurai Level")]
    [SerializeField] private GameObject[] samuraiLevelPrefabs;

    [Header(" Alpinista Level")]
    [SerializeField] private GameObject[] alpinistaLevelPrefabs;


    [SerializeField] private Transform startSpawn;
    [SerializeField] private GameObject[] currentLevelPrefabs;
    [SerializeField] private levelID currentLevelID;
    private GameObject currentPrefab;
    private GameObject lastPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.levelManager = this;
                
        //InitializeLevel(GameController.gameController.currentLevelID);


        InitializeLevel(levelID.CowboyLevel);
    }

    public void InitializeLevel(levelID levelID)
    {
        
        Destroy(currentPrefab);
        Destroy(lastPrefab);

        currentLevelID = levelID;

        if (currentLevelID == levelID.CowboyLevel)
        {
            currentLevelPrefabs = cowboyLevelPrefabsA;
        }
        else if (currentLevelID == levelID.SamuraiLevel)
        {
            currentLevelPrefabs = samuraiLevelPrefabs;
        }
        else if (currentLevelID == levelID.AlpinistaLevel)
        {
            currentLevelPrefabs = alpinistaLevelPrefabs;
        }


        currentPrefab = Instantiate(currentLevelPrefabs[0], startSpawn.position, startSpawn.rotation);

    }

    public void SpawnLevelPrefab()
    {
        GameObject newLevelPrefab = Instantiate(currentLevelPrefabs[0],
            currentPrefab.GetComponent<LevelRoot>().levelPrefabSpawnPoint.position, startSpawn.rotation);

        lastPrefab = currentPrefab;

        currentPrefab = newLevelPrefab;
    }

    public void UpdateLevelPrefabCheckpoint()
    {
        if (currentLevelID == levelID.CowboyLevel)
        {
            currentLevelPrefabs = cowboyLevelPrefabsA;
        }
        else if (currentLevelID == levelID.SamuraiLevel)
        {
            currentLevelPrefabs = samuraiLevelPrefabs;
        }
        else if (currentLevelID == levelID.AlpinistaLevel)
        {
            currentLevelPrefabs = alpinistaLevelPrefabs;
        }
    }

    public void DestroyLevelPrefab()
    {
        Destroy(lastPrefab);
    }

}
