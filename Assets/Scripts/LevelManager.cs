using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private GameObject[] cowboyLevelPrefabs;
    [SerializeField] private GameObject[] samuraiLevelPrefabs;
    [SerializeField] private GameObject[] alpinistaLevelPrefabs;
    [SerializeField] private Transform startSpawn;
    [SerializeField] private GameObject[] currentLevelPrefabs;
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
        //currentLevelPrefabs = levelPrefabs;

        foreach (GameObject prefab in currentLevelPrefabs)
        {
            Destroy(prefab, .1f);
        }


        if (levelID == levelID.CowboyLevel)
        {
            currentLevelPrefabs = cowboyLevelPrefabs;
        }
        else if (levelID == levelID.SamuraiLevel)
        {
            currentLevelPrefabs = samuraiLevelPrefabs;
        }
        else if (levelID == levelID.AlpinistaLevel)
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

    public void DestroyLevelPrefab()
    {
        Destroy(lastPrefab);
    }

}
